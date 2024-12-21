using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("DETAIL")]
    public class Detail
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Column("DESCRIPTION"), MaxLength(500)]
        public string Description { get; set; }

        [Column("SIZE"), MaxLength(50)]
        public string Size { get; set; }

        [Column("ABV")]
        public decimal ABV { get; set; } // double -> decimal

        [Column("AGE")]
        public int Age { get; set; }

        [Column("VARIETAL"), MaxLength(100)]
        public string Varietal { get; set; }

        [Column("STATUS"), MaxLength(50)]
        public string Status { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } // Virtual for Lazy Loading
    }
}
