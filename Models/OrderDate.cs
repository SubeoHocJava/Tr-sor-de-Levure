using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
	[Table("ORDER_DATES")]  // Tên bảng trong cơ sở dữ liệu
	public class OrderDate
	{
		[Key]  // Xác định khóa chính
		[Column("ID")]
		public int Id { get; set; }

		[Column("ORDER_DETAIL_ID")]
		public int OrderDetailId { get; set; }

		[Column("STATE_ID")]
		public int StateId { get; set; }

		[Column("DATE")]
		public DateTime Date { get; set; }

		// Mối quan hệ với OrderState
		[ForeignKey("StateId")]
		public OrderState State { get; set; }
		[ForeignKey("OrderDetailId")]
		public OrderDetail Detail { get; set; }

		public OrderDate(int orderDetailId, int stateId)
		{
			OrderDetailId = orderDetailId;
			StateId = stateId;
			Date = DateTime.Now;
		}

		public OrderDate()
		{

		}
	}
}
