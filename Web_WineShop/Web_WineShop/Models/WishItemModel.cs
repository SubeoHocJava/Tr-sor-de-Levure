using Microsoft.AspNetCore.Mvc;

namespace Web_WineShop.Models
{
    public class WishItemModel
    {
        public int PRODUCT_ID { get; set; }  // Khóa ngoại (Foreign Key) đến bảng Product
        public int USER_ID { get; set; }  // Khóa ngoại (Foreign Key) đến bảng User

       // public virtual Product Product { get; set; }  // Mối quan hệ với Product 
       // public virtual User User { get; set; }  // Mối quan hệ với User 
    }
}
