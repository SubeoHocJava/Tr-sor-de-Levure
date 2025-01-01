using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Dao;
using Web_WineShop.Models.CheckoutModel;
using Web_WineShop.Services;

namespace Web_WineShop.Controllers
{
	public class CheckoutController(AppDBContext context) : Controller
	{
		private readonly AppDBContext _context = context;
		private readonly CheckoutService _service = new CheckoutService(context);

		[HttpGet]
		public async Task<IActionResult> Checkout()
		{
			//	var accId = HttpContext.Session.GetInt32("accId");
			//var voucherId = HttpContext.Session.GetString("Voucher");
			var user = await _service.GetInforUser((int)1, null);
			if (user != null)
			{
				return View(user);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Payment(CheckoutModel data)
		{
			if (!ModelState.IsValid)
			{
				//return View(data);
				return RedirectToAction("Profile", "Profile");
			}
		
			var result = await _service.ProcessPayment(data);
			return Json(result);
		}
		public IActionResult GetPaymentMethod()
		{
			return Ok(_service.GetPaymentMethod());
		}
	}
}
