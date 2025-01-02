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
        public int UserId { get; set; }
        [Column("ORDER_DETAIL_ID"),AllowNull]
        public int? OrderDetailId { get; set; }

        [Column("TOTAL_AMOUNT")]
        public double TotalAmount { get; set; }

        [Column("IS_DELIVERED")]
        public bool IsDelivered { get; set; }
        [ForeignKey("UserId")]
		public User User { get; set; }

        // Mối quan hệ với Order
        [ForeignKey("OrderDetailId")]
        public OrderDetail? Details { get; set; }
		public override string ToString()
		{
			return $"Order ID: {Id}, User ID: {UserId}, Total Amount: {TotalAmount}, Is Delivered: {IsDelivered}";
		}

	}
}
