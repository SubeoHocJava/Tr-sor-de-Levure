using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Web_WineShop.Models
{
    [Table("ORDERS")]  // Tên bảng trong cơ sở dữ liệu
    public class Order
    {
        [Key]  // Khóa chính
        [Column("ID")]
        public int Id { get; set; }

        [Column("USER_ID")]
        public int userId { get; set; }

        [Column("TOTAL_AMOUNT")]
        public double TotalAmount { get; set; }

        [Column("IS_DELIVERED")]
        public bool IsDelivered { get; set; }
        [ForeignKey("userId")]
		public User User { get; set; }

        // Mối quan hệ với Order
        public OrderDetail Details { get; set; }
    }
}
