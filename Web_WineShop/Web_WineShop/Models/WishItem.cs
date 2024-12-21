using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("WISH_ITEM")]
    public class WishItem
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey("Product")]
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        [Column("USER_ID")]
        public int UserId { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
