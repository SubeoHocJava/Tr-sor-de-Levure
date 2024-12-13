using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Wishlist/Wishlist.cshtml");
        }
    }
}
