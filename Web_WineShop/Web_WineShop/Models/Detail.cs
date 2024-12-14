namespace Web_WineShop.Models
{
    public class Detail
    {
        public int Id { get; set; }
        //public Product product { get; set; }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public double ABV { get; set; }

        public int Age { get; set; }
        public string Varietal { get; set; }
        public string Status { get; set; }

        public Product Product { get; set; }

    } 
}
