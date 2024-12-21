using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("REWARD_POINTS")]  // Tên bảng trong cơ sở dữ liệu
    public class RewardPoints
    {
        [Key]  // Khóa chính
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("VALUE")]
        public int Value { get; set; }
    }
}
