namespace Web_WineShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public int Points { get; set; }

        public ICollection<BankAccountOwner > BankAccounts { get; set; }
		public ICollection<Invoice> Invoices { get; set; }

	}
}
