 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("BANK_ACCOUNT")]
    public class BankAccount
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }    
        [ForeignKey("Bank")]
        [Column("BANK_ID")]
        public int BankId { get; set; }
        [Required]
        [Column("ACCOUNT_NO")]
        public long AccountNo { get; set; }
        [Column("BALANCE")]
        public double Balance { get; set; }

		public virtual Bank Bank { get; set; }


		public string getBankName()
		{
			return this.Bank.Name;
		}

	}
}
