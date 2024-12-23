using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("CATEGORY")]
    public class Category
    {
        [Key]
        [Column("ID")]  // Set column name for ID
        public int Id { get; set; }

        [Column("ParentId")]
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; } // Virtual for Lazy Loading

        [Required]
        [MaxLength(100)]
        [Column("Name")]  // Set column name for Name
        public string Name { get; set; }

        [MaxLength(500)]
        [Column("Describe")]
        public string Describe { get; set; }

        [Required]
        [Column("CreationDate", TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [MaxLength(50)]
        [Column("Status")]
        public string Status { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } // Virtual for Lazy Loading
        public virtual ICollection<Product> Products { get; set; } // Virtual for Lazy Loading
    }
}
