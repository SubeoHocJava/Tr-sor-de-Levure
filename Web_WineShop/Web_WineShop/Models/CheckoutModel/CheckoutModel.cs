using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Web_WineShop.Models.CheckoutModel
{
	public class CheckoutModel
	{
		public int UserId { get; set; }
		public string? Name { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
		public int? VoucherId { get; set; }
		[Required(ErrorMessage = "Please choose a payment method")]
		public int PaymentMethodId { get; set; }
		public string Address { get; set; }
		public Voucher? Voucher { get; set; }
		public List<CartItem> Items { get; set; }

		public Double SubTotal()
		{
			return Items.Sum(i => i.Product.Price * i.CartId);
		}

		public Double Discount()
		{
			return Voucher?.getDiscount(SubTotal()) ?? 0;
		}

		public Double TotalAmount()
		{
			return SubTotal() - Discount();
		}

	}
}
