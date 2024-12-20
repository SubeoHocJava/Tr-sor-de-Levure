using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Controllers
{
    public class RumController : Controller
    {
        public IActionResult Rum()
        {
            return View();
        }
    }
}