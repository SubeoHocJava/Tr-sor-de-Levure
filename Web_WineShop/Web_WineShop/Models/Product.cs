using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_WineShop.Models
{
    public class Product
    {

        //public int Id { get; set; }

        //public int BrandId { get; set; }

        //public Brand Brand { get; set; }

        //public int? DetailsId { get; set; }

        //public Detail Detail{ get; set; }

        //public int CategoryId { get; set; }
        //public Category Category { get; set; }

        //public String Name { get; set; }

        //public String ImageUrl { get; set; }

        //public string Appreciation { get; set; }

        //public String Status { get; set; }

        //public double Total()
        //{
        //    return Detail.;
        //}

        [Key]
        public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public int? DetailsId { get; set; }

        [ForeignKey("DetailsId")]
        public virtual Detail Detail { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }

        public string Appreciation { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }
        public double Price { get; set; }

        public double Total()
        {
            return Price;

        }

}
    
}
