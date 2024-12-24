using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Models;
using Web_WineShop.Models.ProfileModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static NuGet.Packaging.PackagingConstants;

namespace Web_WineShop.Controllers
{
	public class ProfileController : Controller
	{
		private readonly AppDBContext _context;
		public ProfileController(AppDBContext context)
		{
			_context = context;
		}
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
		public IActionResult Edit()
		{
			//int? id = HttpContext.Session.GetInt32("accountSession");
			int? id = 1;
			var account = _context.Accounts
										.Include(a => a.User)
										.FirstOrDefault(a => a.id == id);
			if (account == null || account.User == null)
			{
				return NotFound();
			}
			var user = account?.User;
			var model = new UserDetailModel(user.Id, user.FullName, account.Email, user.DateOfBirth, user.Phone, user.ReceiveAddress != null ? user.ReceiveAddress : "");
			return PartialView("_DetailUserView", model);
		}
		[HttpPost]
		public JsonResult Edit(UserDetailModel user)
		{
			if (ModelState.IsValid)
			{
				User? u = _context.Users.Find(user.Id);
				if (u != null)
				{
					u.ReceiveAddress = user.ReceiveAddress;
					u.Phone = user.Phone;
					u.DateOfBirth = user.DateOfBirth;
					u.FullName = user.FullName;
					_context.Users.Update(u);
					return Json(new { success = true });
				}
			}
			else
				foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
				{
					Console.WriteLine(error.ErrorMessage);
				}
			return Json(new { success = false });
		}
		[HttpGet]
		public IActionResult BankAccount()
		{
			//int? id = HttpContext.Session.GetInt32("accountSession");
			int? id = 1;
			var account = _context.Accounts
										.Include(a => a.User)
										.FirstOrDefault(a => a.id == id);
			var user = account?.User;
			var bankAccountOwners = _context.BankAccountOwners
			.Where(bao => bao.UserId == user.Id)
			.Include(bao => bao.BankAccount)
			.ThenInclude(ba => ba.Bank)
			.ToList();
			var model = bankAccountOwners.Select(bao => bao.BankAccount).ToList();
			return PartialView("_BankAccountView", new BankAccountModel(model,user.BankAccountDefaultId));
		}
		[HttpGet]
		public IActionResult OrderHistory()
		{
			int? id = 1;
			var account = _context.Accounts
										.Include(a => a.User)
										.FirstOrDefault(a => a.id == id);
			var user = account?.User;
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
		[HttpPost]
		public JsonResult ChangePass(string password, string newPassword)
		{
			int? id = HttpContext.Session.GetInt32("userId");
			Account? account = _context.Accounts.Find(id);
			if (account?.Password != password)
			{
				return Json(new { success = false });
			}
			else
			{
				account.Password = newPassword;
				_context.Accounts.Update(account);
				return Json(new { success = true });
			}

		}
		[HttpGet]
		public JsonResult Rating(int value, int id)
		{
			OrderItem? item = _context.OrderItems.Find(id);
			if ((item != null))
			{
				item.Rating = value;
				_context.OrderItems.Update(item);
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
		[HttpGet]
		public IActionResult LogOut()
		{
			HttpContext.Session.Remove("accountId");
			return Json(new { redirectUrl = Url.Action("Login", "Login") });
		}

	}
}
