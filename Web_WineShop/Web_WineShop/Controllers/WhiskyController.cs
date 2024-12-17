using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Controllers
{
    public class WhiskyController : Controller
    {
        public IActionResult Whisky()
        {
            return View();
        }
    }
}
