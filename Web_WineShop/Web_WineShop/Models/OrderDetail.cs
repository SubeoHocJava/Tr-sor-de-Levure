﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Web_WineShop.Models
{
	[Table("ORDER_DETAIL")]  // Tên bảng trong cơ sở dữ liệu
	public class OrderDetail
	{
		[Key]
		[Column("ID")]
		public int Id { get; set; }

		[Column("VOUCHER_ID"), AllowNull]
		public int? VoucherId { get; set; }

		[Column("PAYMENT_METHOD_ID")]
		public int PaymentMethodId { get; set; }
		[Column("RECEIVE_ADDRESS")]
		public string ReceiveAddress { get; set; }

		// Mối quan hệ với Voucher
		[ForeignKey("VoucherId")]
		public Voucher? Voucher { get; set; }

		// Mối quan hệ với PaymentMethod
		[ForeignKey("PaymentMethodId")]
		public PaymentMethod PaymentMethod { get; set; }

		public ICollection<OrderItem> Items { get; set; }

		// Mối quan hệ với OrderDates
		public ICollection<OrderDate> Dates { get; set; }

		// Tính tổng giá trị đơn hàng
		public double TotalPrice()
		{
			return Items.Sum(item => item.GetPrice());
		}

		// Tính mức giảm giá của đơn hàng
		public double GetDiscount()
		{
			return 0;
		}
		public override string ToString()
		{
			return $"OrderDetail ID: {Id}, Voucher ID: {VoucherId}, Payment Method ID: {PaymentMethodId}, Total Price: {TotalPrice()}";
		}
	}

}
