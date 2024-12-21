using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Web_WineShop.Models;

namespace Web_WineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly HttpClient _httpClient;

        public ShoppingCartController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> ShoppingCart()
        {
            // Lấy ID người dùng từ session
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Unauthorized();
            }

            var response = await _httpClient.GetAsync($"http://yourapiurl.com/api/ShoppingCartAPI/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var shoppingCart = await response.Content.ReadAsAsync<ShoppingCart>();
                return View(shoppingCart);
            }
            else
            {
                // Xử lý lỗi
                return View(new ShoppingCart(new List<CartItem>()));
            }
        }
    }
}