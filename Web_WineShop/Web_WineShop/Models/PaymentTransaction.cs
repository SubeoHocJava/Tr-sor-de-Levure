using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("PAYMENT_TRANSACTION")]
    public class PaymentTransaction
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ACCOUNT_REF")]
        public int AccountRef { get; set; }

        [ForeignKey("Order")]
        [Column("ORDER_ID")]
        public int OrderId { get; set; }


        [Column("AMOUNT")]
        public decimal Amount { get; set; }

        [Column("STATUS")]
        public string Status { get; set; }

        [Column("TRANSACTION_DATE")]
        public DateTime TransactionDate { get; set; }

        [Column("METHOD_ID")]
        [ForeignKey("PaymentMethod")]
        public int Method_Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Order Order { get; set; }
    }
}
