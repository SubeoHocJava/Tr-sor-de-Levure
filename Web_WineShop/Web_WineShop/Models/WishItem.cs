using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Models
{
    public class WishItem
    {
		public int ProductId { get; set; }
		public int UserId { get; set; }
		public virtual Product Product { get; set; }
		public virtual User User { get; set; }

		 public virtual Product Product { get; set; }  // Mối quan hệ với Product 
		 public virtual User User { get; set; }  // Mối quan hệ với User 
	}
}
