using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
	[Table("VOUCHER")]
	public class Voucher

	{
		[Key, Column("ID")]
		public int Id { get; set; }
		[Required, Column("NAME"), MaxLength(100)]
		public string name { get; set; }
		[Required, Column("DESCRIPTION")]
        public int description { get; set; }
        [Required, Column("PERCENTAGE")]
        public double percentage { get; set; }
        [Required, Column("MAX_DISCOUNT")]
        public double maxDiscount { get; set; }
		public double getDiscount(double price)
		{
			double discount = price - price * percentage;
			return discount > maxDiscount ? maxDiscount : discount;
		}
	}
}
