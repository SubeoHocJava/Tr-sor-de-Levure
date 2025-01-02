	using Web_WineShop.Models;
namespace Web_WineShop.Models
{
	public class ModelViewVoucher
	{
		public List<Voucher> vouchers { get; set; }

		public ModelViewVoucher()
		{
			vouchers = new List<Voucher>();
		}

		public ModelViewVoucher(List<Voucher> vouchers)
		{
			this.vouchers = vouchers ?? new List<Voucher>();
		}

		public void addVoucher(Voucher voucher)
		{
			vouchers?.Add(voucher);
		}
	}
}