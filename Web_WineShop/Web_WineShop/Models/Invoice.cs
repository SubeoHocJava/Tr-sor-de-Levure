namespace Web_WineShop.Models
{
	public class Invoice
	{
		public int Id { get; set; }
		public int CustomerId { get; set; } 
		public double TotalAmount { get; set; }
		public bool IsDelivered { get; set; } 

		public ICollection<Order> Orders { get; set; }
	}

}
