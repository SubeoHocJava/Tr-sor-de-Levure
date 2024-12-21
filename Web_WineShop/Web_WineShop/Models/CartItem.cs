using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_WineShop.Models;
[Table("CART_ITEMS")]
public class CartItem
{
    [Key, Column("ID_KNOWLEDGE")]
    public int UserId { get; set; }
    [ForeignKey("PRODUCT"), Column("PRODUCT_ID")]
    public int ProductId { get; set; } // Foreign Key
    [Required,Column("QUANTITY")]	
    public int Quantity { get; set; }
	public Product Product { get; set; }
    public double total()
    {
        return Product.Price*Quantity;
    }
}
