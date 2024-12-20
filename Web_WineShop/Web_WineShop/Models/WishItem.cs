using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Models
{
    public class WishItem
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey("Product")]
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; } // Khóa ngoại trỏ đến bảng Product

        [ForeignKey("User")]
        [Column("USER_ID")]
        public int UserId { get; set; }    // Khóa ngoại trỏ đến bảng User


        public Product Product { get; set; }

        public User User { get; set; }
    }
}
