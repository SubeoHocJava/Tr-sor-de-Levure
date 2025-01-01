namespace Web_WineShop.Models.ProfileModel
{
	public class OrderHistoryModel
	{
		public ICollection<Order>? Orders { get; set; }

		public OrderHistoryModel(ICollection<Order>? orders)
		{
			Orders = orders;
		}
	}
}
