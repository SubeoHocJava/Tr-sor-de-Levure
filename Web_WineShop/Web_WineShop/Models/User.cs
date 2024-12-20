﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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
		public string Phone { get; set; }
		[Column("COUNTRY")]
		public string Country { get; set; }
		[Column("POINTS")]
		public int Points { get; set; }
		[Column("RECEIVE_ADDRESS")]
		public string? ReceiveAddress { get; set; }
		[Column("BANK_ACC_DEFAULT")]
		public int BankAccountDefaultId { get; set; }
		public BankAccount BankAccountDefault { get; set; }

		public Account Account { get; set; }
		[InverseProperty(nameof(BankAccountOwner.User))]
		public ICollection<BankAccountOwner> BankAccountOwners { get; set; }
		[NotMapped]
		public ICollection<BankAccount> BankAccounts
		{
			get
			{
				return BankAccountOwners != null
					? BankAccountOwners.Select(bao => bao.BankAccount).ToList()
					: new List<BankAccount>();
			}
		}
		public ICollection<Order> Orders { get; set; }
		public bool IsDefaultBank(BankAccount bankAccount)
		{
			return BankAccountDefault.Equals(bankAccount);

		}

	}
}
