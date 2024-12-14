using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Web_WineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int? DetailsId { get; set; }
        public Detail Detail{ get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public String Name { get; set; }

        public string Appreciation { get; set; }

        public String Status { get; set; }

    }
}
