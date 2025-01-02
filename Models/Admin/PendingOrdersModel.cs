namespace Web_WineShop.Models.Admin
{
	public class PendingOrdersModel
	{
		public int OrderId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public double TotalAmount { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderItem> Items { get; set; }
	}
}
