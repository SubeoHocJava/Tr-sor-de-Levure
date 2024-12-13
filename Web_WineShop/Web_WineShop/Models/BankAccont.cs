namespace Web_WineShop.Models
{
	public class BankAccont
	{
		public int Id { get; set; }
		public int BankId { get; set; }
		public int UserId { get; set; }
		public long AccountNo {  get; set; }
		public double Balance { get; set; }

	}
}
