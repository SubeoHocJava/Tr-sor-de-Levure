using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Web_WineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }

        public Details Details{ get; set; }

        public Category category { get; set; }

        public String name { get; set; }

        public String appcreciation { get; set; }

        public String status { get; set; }

    }
}
