using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("BRAND")]
    public class Brand
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Required, Column("NAME"), MaxLength(100)]
        public string Name { get; set; }

        [Column("COUNTRY"), MaxLength(100)]
        public string Country { get; set; }

        [Column("IMG")]
        public string Img { get; set; }

        [Column("COLLAB"), MaxLength(50)]
        public string Collab { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
