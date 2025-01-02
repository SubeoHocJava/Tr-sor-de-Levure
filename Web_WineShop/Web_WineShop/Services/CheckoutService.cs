
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Models;
using Web_WineShop.Models.CheckoutModel;

namespace Web_WineShop.Services
{
	public class CheckoutService
	{
		private readonly AppDBContext _dbContext;

		public CheckoutService(AppDBContext context)
		{
			_dbContext = context;
		}
		public List<PaymentMethod> GetPaymentMethod()
		{
			return _dbContext.PaymentMethods.ToList();
		}
		public async Task<CheckoutModel?> GetInforUser(int accId, int? voucherId)
		{
			var acc = _dbContext.Accounts.Where(a => a.id == accId)
					.Include(a => a.User).First();

			CheckoutModel data = new CheckoutModel();
			if (acc != null)
			{
				var user = acc.User;
				if (voucherId != null)
				{
					data.VoucherId = voucherId;
					data.Voucher = await _dbContext.Vouchers.FindAsync(voucherId);
				}
				data.Items = await _dbContext.CartItems.Where(i => i.User_ID == user.Id)
					.Include(i => i.Product)
					.ToListAsync();
				data.Email = acc.Email;
				data.UserId = user.Id;
				data.Address = user.Address ?? "";
				data.Phone = user.Phone;
				data.Name = user.FullName;
				return data;
			}
			return null;
		}
		public async Task<(bool success, string message)> ProcessPayment( CheckoutModel data)
		{
			if (data == null)
				return (false, "Invalid checkout data");

			if (!await ValidateCheckoutData(data))
				return (false, "Invalid checkout data - please check your cart items and address");

			using var transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				switch (data.PaymentMethodId)
				{
					case 1: 
						var orderResult = await CreateOrder( data);
						if (!orderResult)
						{
							await transaction.RollbackAsync();
							return (false, "Failed to create order");
						}
						await transaction.CommitAsync();
						return (true, "Order created successfully - Payment by cash");
					case 2: 
						var bankResult = await ProcessBankPayment(data.UserId, data);
						if (!bankResult.success)
						{
							await transaction.RollbackAsync();
							return bankResult;
						}
						await transaction.CommitAsync();
						return (true, "Payment processed successfully");
					default:
						return (false, "Unsupported payment method");
				}
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				return (false, "An error occurred during payment processing");
			}
		}
		private async Task<bool> ValidateCheckoutData(CheckoutModel data)
		{
			if (data.Items == null || !data.Items.Any())
				return false;
			foreach (var item in data.Items)
			{
				var product = await _dbContext.Products.FindAsync(item.ProductId);
				//if (product.Stock < item.Quantity)
				//	return false;
			}
			return true;
		}
		private async Task<(bool success, string message)> ProcessBankPayment(int userId, CheckoutModel data)
		{
			var user = await _dbContext.Users
				.Include(u => u.BankAccounts)
				.FirstOrDefaultAsync(u => u.Id == userId);

			var bankAccount = await _dbContext.BankAccounts
				.FindAsync(user?.BankAccountDefaultId);

			if (bankAccount == null)
				return (false, "Bank account not found");

			if (bankAccount.Balance < data.TotalAmount())
				return (false, "Insufficient balance");

			bankAccount.Balance -= data.TotalAmount();
			_dbContext.BankAccounts.Update(bankAccount);

			if (!await CreateOrder( data))
				return (false, "Failed to create order");

			await _dbContext.SaveChangesAsync();
			return (true, "Payment processed successfully");
		}
		private async Task<bool> CreateOrder( CheckoutModel data)
		{
			try
			{
				var orderDetail = new OrderDetail
				{
					VoucherId = data.VoucherId,
					PaymentMethodId = data.PaymentMethodId,
					ReceiveAddress = data.Address,
				};

				var order = new Order
				{
					UserId = data.UserId,
					TotalAmount = data.TotalAmount(),
					Details = orderDetail,
				};

				var orderDate = new OrderDate
				{
					StateId = 1, // Initial state
					Detail = orderDetail,
					Date = DateTime.UtcNow
				};

				var orderItems = data.Items.Select(item => new OrderItem
				{
					OrderDetail = orderDetail,
					ProductId = item.ProductId,
					Quantity = item.Quantity,
				}).ToList();

				await _dbContext.OrderDetails.AddAsync(orderDetail);
				await _dbContext.Orders.AddAsync(order);
				await _dbContext.OrderDates.AddAsync(orderDate);
				await _dbContext.OrderItems.AddRangeAsync(orderItems);

				// Update product stock
				foreach (var item in data.Items)
				{
					var product = await _dbContext.Products.FindAsync(item.ProductId);
					//if (product != null)
					//{
					//	product.Stock -= item.Quantity;
					//	_dbContext.Products.Update(product);
					//}
				}

				return await _dbContext.SaveChangesAsync() > 0;
			}
			catch
			{
				return false;
			}
		}
	}
}
