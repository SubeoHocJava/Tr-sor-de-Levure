using System.Collections.Generic;

namespace Web_WineShop.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }
        public ShoppingCart() { 
        this.Items = new List<CartItem>();
        }
 
    // Phương thức thêm item vào giỏ hàng
    public void AddItem(CartItem item)
    {
            Items.Add(item);
    }
}
    }
