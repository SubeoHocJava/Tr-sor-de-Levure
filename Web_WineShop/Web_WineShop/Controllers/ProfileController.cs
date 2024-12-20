/*using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Dao;
using Web_WineShop.Models;

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
			int? id = HttpContext.Session.GetInt32("userId");
			Account? account = _context.Accounts.Find(id);
			return View(account?.User);
		}
		[HttpPost]
		public JsonResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				User? u = _context.Users.Find(user.Id);
				if (u != null)
				{
					u.Address = user.Address;
					u.Phone = user.Phone;
					u.DoB = user.DoB;
					u.FullName = user.FullName;
					_context.Users.Update(u);
					return Json(new { success = true });
				}
			}
			return Json(new { success = false });
		}
		[HttpPost]
		public JsonResult ChangePass(string password, string newPassword)
		{
				int? id = HttpContext.Session.GetInt32("userId");
				Account? account = _context.Accounts.Find(id);
				if (account?.password != password)
				{
					return Json(new { success = false });
				}
				else
				{
					account.password = newPassword;
					_context.Accounts.Update(account);
					return Json(new { success = true });
				}

		}
		[HttpGet]
		public JsonResult Rating(int value, int id)
		{
				OrderItem? item = _context.OrderItems.Find(id);
                if ((item!=null))
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
			HttpContext.Session.Remove("userId");
			return RedirectToAction("Login", "Login");
		}

	}
}
*/