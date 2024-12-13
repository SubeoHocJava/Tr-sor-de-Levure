using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Admin()
		{
			return View();
		}
	}
}
