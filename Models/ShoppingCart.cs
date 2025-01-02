namespace Web_WineShop.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }
        public double Discount { get; set; }
        public double OriginalTotal { get; set; }
        // Giá trước khi giảm giá
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
            Discount = 0;
            OriginalTotal = 0;
        }

        public ShoppingCart(List<CartItem> cartItems)
        {
            this.Items = cartItems;
            Discount = 0;
            OriginalTotal = Total; // Đặt giá trị ban đầu
        }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }
    }
}
