using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace Web_WineShop.Models
{
	[Table("USER")]
	public class User
	{
		[Key]
		[Column("ID")]
		public int Id { get; set; }
		[Required]
		[Column("FULLNAME")]
		public string FullName { get; set; }
		[Column("GENDER")]
		public string Gender { get; set; }
		[Column("DOB")]
		public DateTime DateOfBirth { get; set; }
		[Column("PHONE")]
		[Phone(ErrorMessage = "Invalid phone number.")]
		public string Phone { get; set; }
		[Column("COUNTRY")]
		public string Country { get; set; }
		[Column("POINTS")]
		public int Points { get; set; }
		[Column("RECEIVE_ADDRESS"), AllowNull]
		public string? ReceiveAddress { get; set; }
		[Column("BANK_ACC_DEFAULT"), AllowNull]
		public int? BankAccountDefaultId { get; set; }


		public Account Account { get; set; }
		[InverseProperty(nameof(BankAccountOwner.User))]
		public ICollection<BankAccountOwner>? BankAccountOwners { get; set; }
		[NotMapped]
		public ICollection<BankAccount>? BankAccounts
		{
			get; set;
		}
		[InverseProperty("User")]
		public ICollection<Order> Orders { get; set; }


	}
}
