
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web_WineShop.Dao;
using Web_WineShop.Models;
using Web_WineShop.Models.ProfileModel;

namespace Web_WineShop.Controllers
{
	public class ProfileController(AppDBContext context, HttpClient httpClient, ILogger<ProfileController> logger) : Controller
	{
		private readonly AppDBContext _context = context;
		private readonly HttpClient _httpClient = httpClient;
		private readonly ILogger<ProfileController> _logger = logger;

		public IActionResult Profile()
		{
			//int? id = HttpContext.Session.GetInt32("accountSession");
			int? id = 1;
			var account = _context.Accounts
										.Include(a => a.User)
										.FirstOrDefault(a => a.id == id);
			var user = account?.User;
			if (user != null)
				user.Account = account;
			else return RedirectToAction("Login", "Login");
			return View(user);
		}
		[HttpGet]
		public IActionResult Overview(int id)
		{
			var model = _context.Users.FirstOrDefault(u => u.Id == id);
			return PartialView("_AccountOverviewView", model);
		}
		#region Detail User
		[HttpGet]
		public IActionResult Edit()
		{
			//int? id = HttpContext.Session.GetInt32("accountSession");
			int? id = 1;
			var account = _context.Accounts
										.Include(a => a.User)
										.FirstOrDefault(a => a.id == id);
			if (account == null || account?.User == null)
			{
				return NotFound();
			}
			var user = account?.User;
			var model = new UserDetailModel();
			if (user != null)
				model = new UserDetailModel(user.Id, user.FullName, account.Email, user.DateOfBirth, user.Phone, user.ReceiveAddress != null ? user.ReceiveAddress : "");
			return PartialView("_DetailUserView", model);
		}
		[HttpPost]
		public JsonResult Edit(UserDetailModel user)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Where(m => m.Value.Errors.Any())
							.ToDictionary(
								field => field.Key,
								field => field.Value.Errors.Select(e => e.ErrorMessage).ToArray());
				return Json(new { success = false, errors });
			}

			User? u = _context.Users.Find(user.Id);
			if (u != null)
			{
				u.ReceiveAddress = user.ReceiveAddress;
				u.Phone = user.Phone;
				u.DateOfBirth = user.DateOfBirth;
				u.FullName = user.FullName;
				_context.Users.Update(u);
				_context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
		#endregion
		#region Bank Account
		[HttpGet]
		public IActionResult BankAccount(int id)
		{
			var user = _context.Users.FirstOrDefault(u => u.Id == id);
			var bankAccountOwners = _context.BankAccountOwners
			.Where(bao => bao.UserId == user.Id)
			.Include(bao => bao.BankAccount)
			.ThenInclude(ba => ba.Bank)
			.ToList();
			var model = bankAccountOwners.Select(bao => bao.BankAccount).ToList();
			return PartialView("_BankAccountView", new BankAccountModel(id, model, user.BankAccountDefaultId));
		}
		[HttpPost]
		public async Task<JsonResult> AddBankAccount(BankAccountModel bankAccount)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Where(m => m.Value.Errors.Any())
							.ToDictionary(
								field => field.Key,
								field => field.Value.Errors.Select(e => e.ErrorMessage).ToList());
				return Json(new { success = false, errors });
			}

			var content = new
			{
				idBank = bankAccount.BankId,
				no = bankAccount.AccountNo
			};
			using var response = await _httpClient.PostAsync($"{Request.Scheme}://{Request.Host}/api/BankApi/Exist", JsonContent.Create(content));
			if (response.IsSuccessStatusCode)
			{
				string dataResponse = await response.Content.ReadAsStringAsync();
				var bankAcc = JsonConvert.DeserializeObject<BankAccount>(dataResponse);
				if (bankAcc != null)
				{
					if (_context.BankAccountOwners.Any(bao => bao.BankAccountId == bankAcc.Id && bao.UserId == bankAccount.Id))
						return Json(new { success = false, message = "Bank account already exists." });
					await _context.BankAccountOwners.AddAsync(new BankAccountOwner(bankAcc.Id, bankAccount.Id));
					await _context.SaveChangesAsync();
					var data = new
					{
						bankAccId = bankAcc.Id,
						accountNo = bankAcc.AccountNo,
						bankName = _context.Banks.First(b => b.Id == bankAccount.BankId).Name,
						userId = bankAccount.Id
					};
					return Json(new
					{
						success = true,
						data
					});
				}

			}
			else if (response.StatusCode == HttpStatusCode.NotFound)
			{
				return Json(new { success = false, message = await response.Content.ReadAsStringAsync() });
			}
			return Json(new { success = false });

		}
		[HttpPost]
		public JsonResult SetDefaultBank([FromBody] JsonElement data)
		{
			int idBank = data.GetProperty("idBank").GetInt32();
			int id = data.GetProperty("id").GetInt32(); ;
			Console.WriteLine(idBank + " " + id);
			var user = _context.Users.FirstOrDefault(u => u.Id == id);
			if (user == null)
			{
				return Json(new { success = false });
			}
			user.BankAccountDefaultId = idBank;
			_context.Users.Update(user);
			_context.SaveChanges();
			return Json(new { success = true });
		}
		#endregion
		#region Change Password
		[HttpGet]
		public IActionResult ChangePassword()
		{
			return PartialView("_ChangePassView");
		}
		[HttpPost]
		public JsonResult ChangePass(PasswordUserModel PassModel)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Where(m => m.Value.Errors.Any())
									   .ToDictionary(
										field => field.Key,
										field => field.Value.Errors.Select(e => e.ErrorMessage).ToArray());
				return Json(new { success = false, errors });
			}
			int? id = HttpContext.Session.GetInt32("userId");
			Account? account = _context.Accounts.Find(id);
			if (account?.Password != PassModel.Password)
			{
				return Json(new { success = false, message = "Current password is incorrect" });
			}
			else
			{
				account.Password = PassModel.NewPassword;
				_context.Accounts.Update(account);
				_context.SaveChanges();
				return Json(new { success = true });
			}

		}
		#endregion

		#region  Order History
		[HttpGet]
		public IActionResult OrderHistory(int id)
		{
			var user = _context.Users.FirstOrDefault(u => u.Id == id);
			var orders = _context.Orders
				.Where(o => o.UserId == id)
				.Include(order => order.Details)
				.ThenInclude(od => od.Dates)
				.ThenInclude(od => od.State)
				.ToList();
			var orderDetails = _context.OrderDetails
				.Include(od => od.Voucher)
				.Include(od => od.PaymentMethod)
				.Include(od => od.Items)
				.ThenInclude(oi => oi.Product)
				.ToDictionary(od => od.Id);
			foreach (var order in orders)
			{
				if (order.Details != null && orderDetails.TryGetValue((int)order.OrderDetailId, out OrderDetail detail))
				{
					order.Details.Voucher = detail.Voucher;
					order.Details.Items = detail.Items;
					order.Details.PaymentMethod = detail.PaymentMethod;
				}
			}
			return PartialView("_OrderHistoryView", new OrderHistoryModel(orders));
		}

		[HttpGet]
		public IActionResult LoadOrderView(int id)
		{

			var order = _context.Orders.Where(o => o.Id == id)
				.Include(order => order.Details)
				.ThenInclude(od => od.Dates)
				.ThenInclude(od => od.State)
				.FirstOrDefault();
			var orderDetails = _context.OrderDetails
				.Where(od => od.Id == order.OrderDetailId)
				.Include(od => od.Voucher)
				.Include(od => od.PaymentMethod)
				.Include(od => od.Items)
				.ThenInclude(oi => oi.Product).FirstOrDefault();
			orderDetails.Dates = order.Details.Dates;
			order.Details = orderDetails;
			return PartialView("_OrderView", order);

		}
		[HttpPost]
		public JsonResult Rating([FromBody] JsonElement data)
		{
			int idProduct = data.GetProperty("idProduct").GetInt32();
			int idItem = data.GetProperty("idItem").GetInt32();
			int value = data.GetProperty("value").GetInt32();
			OrderItem? item = _context.OrderItems.Find(idProduct, idItem);
			if ((item != null))
			{
				item.Rating = value;
				_context.OrderItems.Update(item);
				_context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		[HttpPut]
		public JsonResult Delivered(int id)
		{
			Order? order = _context.Orders.Find(id);
			if (order != null)
			{
				order.IsDelivered = true;
				OrderDate date = new OrderDate((int)order.OrderDetailId, 4);
				_context.Orders.Update(order);
				_context.OrderDates.Add(date);
				_context.SaveChanges();
				return Json(new
				{
					success = true
				});
			}
			return Json(new { success = false, message = "Order not found" });
		}

		#endregion
		[HttpGet]
		public IActionResult LogOut()
		{
			HttpContext.Session.Remove("userId");
			return RedirectToAction("Login", "Login");
		}

	}
}
