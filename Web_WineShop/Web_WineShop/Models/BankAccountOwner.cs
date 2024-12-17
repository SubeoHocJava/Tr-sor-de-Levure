namespace Web_WineShop.Models
{
	public class BankAccountOwner
	{
		public int BankAccountId { get; set; }
		public int UserId { get; set; }

		public BankAccount BankAccount { get; set; }
	}
}
