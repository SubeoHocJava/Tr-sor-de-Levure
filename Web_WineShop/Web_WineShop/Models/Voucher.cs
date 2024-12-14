namespace Web_WineShop.Models
{
    public class Voucher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int description { get; set; }
        public string percentage { get; set; }
        public double maxDiscount { get; set; }
    }
}
