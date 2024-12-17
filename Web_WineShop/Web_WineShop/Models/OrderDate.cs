namespace Web_WineShop.Models
{
	public class OrderDate
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int StateId { get; set; }
		public DateTime Date { get; set; }

		public OrderState State { get; set; }

	}
}
