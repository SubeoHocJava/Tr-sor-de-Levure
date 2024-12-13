using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Profile()
		{
			return View();
		}
	}
}
