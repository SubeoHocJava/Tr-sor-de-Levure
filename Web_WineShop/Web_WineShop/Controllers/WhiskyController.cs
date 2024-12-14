using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Models;

namespace Web_WineShop.Controllers
{
    public class WhiskyController : Controller
    {
        public IActionResult Product()
        {
            return View();
        }
    }
}
