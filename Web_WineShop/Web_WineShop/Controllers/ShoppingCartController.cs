using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Models;

namespace Web_WineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCartView()
        {
            return View(_shoppingCart);
        }

        // Thêm các hành động khác như thêm sản phẩm vào giỏ hàng, áp dụng voucher, v.v.
        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityModel model)
        {
            var item = ShoppingCart.Items.FirstOrDefault(x => x.ProductId == model.ProductId);
            if (item != null)
            {
                item.Quantity = model.Quantity;
                item.Total = item.Quantity * item.Price;
            }
            ShoppingCart.UpdateCartTotal();
            return Json(new
            {
                total = item.Total,
                cartTotal = ShoppingCart.Total,
                finalTotal = ShoppingCart.FinalTotal,
                discount = ShoppingCart.Discount
            });
        }

        [HttpPost]
        public IActionResult ApplyVoucher([FromBody] Voucher model)
        {
            ShoppingCart.ApplyVoucher(model.maxDiscount);
            return Json(new
            {
                cartTotal = ShoppingCart.Total,
                finalTotal = ShoppingCart.FinalTotal,
                discount = ShoppingCart.Discount
            });
        }
    }
}
