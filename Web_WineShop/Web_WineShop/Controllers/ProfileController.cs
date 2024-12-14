using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Dao;

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
			return View();
		}
	}
}
