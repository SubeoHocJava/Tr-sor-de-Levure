using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Dao;
using Web_WineShop.Models;
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
			var accId = HttpContext.Session.GetInt32("accId") ?? 0;
			if (accId == 0)
			{
				return RedirectToAction("Login", "Login");
			}
			var shoppingCartJson = HttpContext.Session.GetString("ShoppingCart");
			if (String.IsNullOrEmpty(shoppingCartJson))
			{
				return Json(new { success = false, message = "Giỏ hàng trống." });
			}
			var shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(shoppingCartJson);
			var voucher = JsonSerializer.Deserialize<Voucher>(HttpContext.Session.GetString("Voucher")); ;
			var user = await _service.GetInforUser(accId, voucher?.Id, shoppingCart.Items);
			if (user != null)
			{
				return View(user);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Checkout(CheckoutModel data)
		{
			var shoppingCartJson = HttpContext.Session.GetString("ShoppingCart");
			if (String.IsNullOrEmpty(shoppingCartJson))
			{
				return RedirectToAction("ShopingCart", "ShopingCart");
			}
			var shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(shoppingCartJson);
			var items = shoppingCart.Items;
			data.Items = items;
			if (data.Address == null)
			{
				var paymentErrors = ModelState
					.Where(m => m.Key.Equals("Address"))
					.SelectMany(m => m.Value.Errors)
					.Select(e => e.ErrorMessage)
					.FirstOrDefault();
				return Json(new { paymentErrors });
			}
			var result = await _service.ProcessPayment(data);
			return Json(new { result.success, result.message });
		}
		public IActionResult GetPaymentMethod()
		{
			return Ok(_service.GetPaymentMethod());
		}
	}
}
