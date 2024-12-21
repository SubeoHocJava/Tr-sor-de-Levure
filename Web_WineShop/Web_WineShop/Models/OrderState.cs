using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("ORDER_STATE")]  // Tên bảng trong cơ sở dữ liệu
    public class OrderState
    {
        [Key]  // Chỉ định đây là khóa chính
        [Column("ID")]  // Tên cột trong cơ sở dữ liệu
        public int Id { get; set; }

        [Required]  // Đảm bảo trường này là bắt buộc
        [Column("STATE_NAME")]  // Tên cột trong cơ sở dữ liệu
        [StringLength(100)]  // Giới hạn độ dài của trường này
        public string StateName { get; set; }
    }
}
