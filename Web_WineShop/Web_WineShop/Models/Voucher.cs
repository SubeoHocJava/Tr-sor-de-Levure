namespace Web_WineShop.Models
{
    public class Voucher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int decription { get; set; }
        public string percentage { get; set; }
        public double maxDiscount { get; set; }

        public Voucher (int id, string name, int decription, string percentage, double maxDiscount)
        {
            this.id = id;
            this.name = name;
            this.decription = decription;
            this.percentage = percentage;
            this.maxDiscount = maxDiscount;
        }
    }
}
