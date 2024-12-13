namespace Web_WineShop.Models
{
    public class Account
    {
        public Violate violate {  get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime createDate { get; set; }
        public int role { get; set; }
        public bool Ban { get; set; }

    }
}
