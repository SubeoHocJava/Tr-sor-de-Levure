using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Models.CheckoutModel;

namespace Web_WineShop.Controllers
{
	public class CheckoutController(AppDBContext context) : Controller
	{
		private readonly AppDBContext _context = context;

		[HttpGet]
		public async Task<IActionResult> Checkout()
		{
			var accId = HttpContext.Session.GetInt32("accId");
			var user = (await _context.Accounts.FindAsync(accId)).User;
			var voucherId = HttpContext.Session.GetString("Voucher");
			CheckoutModel model = new CheckoutModel();
			if (user != null)
			{
				model.UserId = user.Id;
				model.Address = user.ReceiveAddress;
				model.Phone = user.Phone;
				model.Name = user.FullName;
				model.Email = (await _context.Accounts.FindAsync(accId)).Email;
				if (voucherId != null)
				{
					model.VoucherId = voucherId;
					model.Voucher = _context.Vouchers.Find(voucherId);
				}
				model.Items = await _context.CartItems.Where(i => i.User_ID == model.UserId).ToListAsync();
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> CheckOut(CheckoutModel data)
		{
			if (!ModelState.IsValid)
			{
				return View(data);
			}

			return null;
		}
	}
}
