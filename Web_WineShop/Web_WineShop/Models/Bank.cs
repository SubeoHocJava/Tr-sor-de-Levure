using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("BANK")]
    public class Bank
	{
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column("NAME")]
        public string Name { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
