namespace Web_WineShop.Models
{
	public class BankAccount
	{
		public int Id { get; set; }
		public int BankId { get; set; }
		public long AccountNo { get; set; }
		public double Balance { get; set; }

		public Bank Bank { get; set; }

	}
}
