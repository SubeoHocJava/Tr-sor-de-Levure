namespace Web_WineShop.Models
{
	public class OrderItem
	{
		public int ProductId { get; set; }
		public int OrderId { get; set; }
		public int Quantity { get; set; }
		public int Appreciation { get; set; }
	}
}
