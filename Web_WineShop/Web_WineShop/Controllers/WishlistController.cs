using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult SendToFriend()
        {
            return View();
        }

    }
}
