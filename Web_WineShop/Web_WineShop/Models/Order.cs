namespace Web_WineShop.Models
{
	public class Order
	{
		public int Id { get; set; }
		public int VoucherId { get; set; }
		public int InvoiceId { get; set; }
		public int PaymentMethodId { get; set; }

		public PaymentMethod PaymentMethod { get; set; }
		public ICollection<OrderItem> Items { get; set; }
		public ICollection<OrderDate> Dates { get; set; }
	}
}
