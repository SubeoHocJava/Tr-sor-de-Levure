﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("DETAIL")]
    public class Detail
    {
        [Key]
        [Column("ID")]  // Set column name for ID
        public int Id { get; set; }

        [MaxLength(500)]
        [Column("Description")]
        public string Description { get; set; }

        [MaxLength(50)]
        [Column("Size")]
        public string Size { get; set; }

        [Column("ABV")]
        public double ABV { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        [MaxLength(100)]
        [Column("Varietal")]
        public string Varietal { get; set; }

        [MaxLength(50)]
        [Column("Status")]
        public string Status { get; set; }

        public virtual ICollection<Product> Products { get; set; } // Virtual for Lazy Loading
    }
}
