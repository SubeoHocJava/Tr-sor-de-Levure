namespace Web_WineShop.Models
{
    public class PasswordResetRequest
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Account Account { get; set; }
    }
}
