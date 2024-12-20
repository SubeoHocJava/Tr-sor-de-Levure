using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("BANK_ACCOUNT_OWNER")]
    public class BankAccountOwner
    {
        [Column("BANK_ACCOUNT_ID", Order = 0)]
        public int BankAccountId { get; set; }

        [Column("USER_ID", Order = 1)]
        public int UserId { get; set; }
    }
}
