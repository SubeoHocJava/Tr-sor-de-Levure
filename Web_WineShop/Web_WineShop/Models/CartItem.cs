namespace Web_WineShop.Models;

public class CartItem
{
	public int UserId { get; set; }
	public int ProductId { get; set; } // Foreign Key
	public int Quantity { get; set; }

	public Product Product { get; set; }
}
