using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("BRAND")]
    public class Brand
    {
        [Key]
        [Column("ID")]  // Set column name for ID
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Name")]  // Set column name for Name
        public string Name { get; set; }

        [MaxLength(100)]
        [Column("Country")]
        public string Country { get; set; }

        [Column("Img")]
        public string Img { get; set; }

        [MaxLength(50)]
        [Column("Collab")]
        public string Collab { get; set; }
        public virtual ICollection<Product> Products { get; set; } // Virtual for Lazy Loading
    }
}
