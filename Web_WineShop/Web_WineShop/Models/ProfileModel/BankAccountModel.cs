using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models.ProfileModel
{
	public class BankAccountModel
	{
		public ICollection<BankAccount>? BankAccounts { get; set; }
		public int? BankAccountDefaultId { get; set; }
		public bool IsDefaultBank(BankAccount bankAccount)
		{
			return BankAccountDefaultId == bankAccount.Id;

		}

		public BankAccountModel(ICollection<BankAccount>? bankAccounts, int? bankAccountDefaultId)
		{
			BankAccounts = bankAccounts;
			BankAccountDefaultId = bankAccountDefaultId;
		}
	}
}
