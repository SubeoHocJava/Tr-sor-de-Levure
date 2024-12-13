namespace Web_WineShop.Models
{
    public class CartItem
    {
        public Product product { get; set; }
        public int quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
    }
}
