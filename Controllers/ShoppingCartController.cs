using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using Web_WineShop.Dao;
using Web_WineShop.Models;

public class ShoppingCartController : Controller
{
    private readonly HttpClient _httpClient;
    private AppDBContext _dbContext;

    public ShoppingCartController(HttpClient httpClient, AppDBContext appDBContext)
    {
        _httpClient = httpClient;
        _dbContext = appDBContext;
    }

    public async Task<IActionResult> ShoppingCart()
    {
        var response = await _httpClient.GetAsync($"https://localhost:7053/api/ShoppingCartAPI/{1}");
        if (response.IsSuccessStatusCode)
        {
            var shoppingCart = await response.Content.ReadAsAsync<ShoppingCart>();
            HttpContext.Session.SetString("ShoppingCart", JsonSerializer.Serialize(shoppingCart));
            return View(shoppingCart);
        }
        else
        {
            return View(new ShoppingCart(new List<CartItem>()));
        }
    }


    [HttpPost]
    public IActionResult ApplyVoucher(String voucherCode)
    {
        Console.WriteLine("+++++" + voucherCode + "------"); // In voucherCode ra để kiểm tra

        // Lấy giỏ hàng từ session (giả sử là chuỗi JSON)
        var shoppingCartJson = HttpContext.Session.GetString("ShoppingCart");

        if (String.IsNullOrEmpty(shoppingCartJson))
        {
            return Json(new { success = false, message = "Giỏ hàng trống." });
        }

        var shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(shoppingCartJson); // Deserialize giỏ hàng từ chuỗi JSON

        if (String.IsNullOrEmpty(voucherCode))
        {
            return Json(new { success = false, message = "Vui lòng nhập mã voucher." });
        }

        // Kiểm tra voucher hợp lệ
        var voucher = _dbContext.Vouchers.FirstOrDefault(v => v.name == voucherCode);
        if (voucher == null)
        {
            return Json(new { success = false, message = "Mã voucher không hợp lệ." });
        }

        HttpContext.Session.SetString("Voucher", JsonSerializer.Serialize(voucher)); // Lưu voucher vào session dưới dạng JSON

        // Tính toán giảm giá và tổng giỏ hàng
        shoppingCart.Discount = voucher.getDiscount(shoppingCart.Total);
        var originalTotal = shoppingCart.OriginalTotal;

        return Json(new
        {
            success = true,
            cartTotal = originalTotal,
            finalTotal = originalTotal - shoppingCart.Discount,
            discount = shoppingCart.Discount
        });
    }

    [HttpPost]
    public IActionResult UpdateQuantity(int productId, int quantity)
    {
        // Lấy giỏ hàng từ session hoặc cơ sở dữ liệu
        var shoppingCartJson = HttpContext.Session.GetString("ShoppingCart");
        var shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(shoppingCartJson);
        var cartItem = shoppingCart.Items.FirstOrDefault(i => i.Product.Id == productId);

        if (cartItem == null)
        {
            return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
        }

        // Kiểm tra tồn kho
        var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {
            return Json(new { success = false, message = "Sản phẩm không tồn tại." });
        }

        if (quantity > product.Stock)
        {
            return Json(new { success = false, message = "Số lượng sản phẩm không đủ trong kho." });
        }

        // Cập nhật số lượng trong giỏ hàng
        cartItem.Quantity = quantity;

        // Tính lại tổng tiền của sản phẩm
        var itemTotal = cartItem.Quantity * cartItem.Product.Price;

        // Tính lại tổng tiền giỏ hàng
        var cartTotal = shoppingCart.Items.Sum(i => i.Quantity * i.Product.Price);

        // Lưu giỏ hàng vào session hoặc cơ sở dữ liệu
        HttpContext.Session.SetString("ShoppingCart", JsonSerializer.Serialize(shoppingCart));

        return Json(new
        {
            success = true,
            newQuantity = cartItem.Quantity,
            itemTotal = itemTotal,
            cartTotal = cartTotal
        });
    }

}