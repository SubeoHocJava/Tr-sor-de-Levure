namespace Web_WineShop.Models
{
	public class Voucher
	{
		public int id { get; set; }
		public string name { get; set; }
		public int description { get; set; }
		public double percentage { get; set; }
		public double maxDiscount { get; set; }
		public double getDiscount(double price)
		{
			double discount = price - price * percentage;
			return discount > maxDiscount ? maxDiscount : discount;
		}
	}
}
