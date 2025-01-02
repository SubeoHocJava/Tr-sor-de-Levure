using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Controllers
{
    public class GinController : Controller
    {
        public IActionResult Gin()
        {
            return View();
        }
    }
}
