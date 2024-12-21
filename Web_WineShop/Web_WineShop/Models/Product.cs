using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("PRODUCT")]
    public class Product
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("BRAND_ID")]
        public int BrandId { get; set; }

        [Column("DETAILS_ID")]
        public int? DetailsId { get; set; }

        [Required, Column("CATEGORY_ID")]
        public int CategoryId { get; set; }

        [Required, Column("NAME"), MaxLength(200)]
        public string Name { get; set; }

        [Column("PRICE")]
        public int Price { get; set; }

        [Column("APPRECIATION")]
        public string Appreciation { get; set; }

        [Column("STATUS"), MaxLength(50)]
        public string Status { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("DetailsId")]
        public Detail Detail { get; set; }
    }
}
