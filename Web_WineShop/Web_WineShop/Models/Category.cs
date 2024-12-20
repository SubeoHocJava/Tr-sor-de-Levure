using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("CATEGORY")]
    public class Category
    {
        [Key, Column("ID")]
        public int Id { get; set; }

        [Column("PARENT_ID")]
        public int? ParentId { get; set; }

        [Required, Column("NAME"), MaxLength(100)]
        public string Name { get; set; }

        [Column("DESCRIBE"), MaxLength(500)]
        public string Describe { get; set; }

        [Required, Column("CREATION_DATE", TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [Column("STATUS"), MaxLength(50)]
        public string Status { get; set; }

        [ForeignKey("ParentId")]
        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}