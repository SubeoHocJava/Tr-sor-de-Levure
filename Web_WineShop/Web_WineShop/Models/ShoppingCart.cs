using System.Collections.Generic;

namespace Web_WineShop.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }

        // Thêm thuộc tính Total vào ShoppingCart
        public double Total
        {
            get
            {
                return Items.Sum(item => item.Product.Price * item.Quantity);
            }
        }

        public ShoppingCart()
        {
            this.Items = new List<CartItem>();
        }
        public ShoppingCart(List<CartItem> cartItems)
        {
            this.Items = cartItems;
        }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }
    }

}
