using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Web_WineShop.Controllers
{
    public class Send_to_friendController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Wishlist/Send_to_friend.cshtml");
        }
    }
}
