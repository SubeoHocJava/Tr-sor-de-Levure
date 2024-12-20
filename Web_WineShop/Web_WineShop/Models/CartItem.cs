using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("CART_ITEM")] // Đặt tên bảng là "CART_ITEM"
    public class CartItem
    {

        [Key] // Đặt khóa chính (tùy thuộc vào quy ước, có thể thêm khóa chính composite)
        [Column("USER_ID")] // Đặt tên cột là "USER_ID"
        public int UserId { get; set; } // Khóa ngoại trỏ đến bảng User

        [Column("PRODUCT_ID")] // Đặt tên cột là "PRODUCT_ID"
        public int ProductId { get; set; } // Khóa ngoại trỏ đến bảng Product

        [Column("QUANTITY")] // Đặt tên cột là "QUANTITY"
        public int Quantity { get; set; }

        // Navigation property trỏ đến bảng Product
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        // Navigation property trỏ đến bảng User
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}