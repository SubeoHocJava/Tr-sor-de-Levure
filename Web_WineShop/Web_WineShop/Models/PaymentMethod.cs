using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
	[Table("PAYMENTMETHOD")]
	public class PaymentMethod
	{
		[Key]
		[Column("ID")]
		public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
	}
}
