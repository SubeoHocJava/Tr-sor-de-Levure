using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Web_WineShop.Models.ProfileModel
{
	public class BankAccountModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Bank Name is required.")]
		public int BankId { get; set; }
		[Required(ErrorMessage = "Account number is required.")]
		[RegularExpression(@"^\d+$", ErrorMessage = "Account number must be a valid number.")]
		public long AccountNo { get; set; }
		private ICollection<BankAccount> _bankAccounts;
		public int? BankAccountDefaultId { get; set; }
		public ICollection<BankAccount>? BankAccounts
		{
			get
			{
				if (_bankAccounts == null) return null;
				var defaultAccount = _bankAccounts.First(b => b.Id == BankAccountDefaultId);
				var otherAccounts = _bankAccounts.Where(b => b.Id != BankAccountDefaultId).ToList();
				otherAccounts.Insert(0, defaultAccount);
				return otherAccounts;
			}
			set
			{
				_bankAccounts = value;
			}
		}
		public bool IsDefaultBank(BankAccount bankAccount)
		{
			return BankAccountDefaultId == bankAccount.Id;

		}
		public override string ToString()
		{

			return $"BankAccountModel [Id: {Id}, BankId: {BankId}, AccountNo: {AccountNo}";
		}

		public BankAccountModel(int id, ICollection<BankAccount>? bankAccounts, int? bankAccountDefaultId)
		{
			Id = id;
			BankAccounts = bankAccounts;
			BankAccountDefaultId = bankAccountDefaultId;
		}
		public BankAccountModel()
		{
		}

	}
}
