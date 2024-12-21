using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("VIOLATE")]
    public class Violate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [ForeignKey("Account")]
        [Column("ACCOUNT_ID")]
        public int AccountId { get; set; }
        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        // Navigation Property đến Account
        public virtual Account Account { get; set; }
    }
}
