using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("ORDER_ITEM")]  // Tên bảng trong cơ sở dữ liệu
    public class OrderItem
    {
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Column("DETAIL_ID")]
        public int OrderId { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("RATING")]
        public int Rating { get; set; }

        // Các mối quan hệ khóa ngoại
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        // Phương thức tính giá trị của OrderItem
        public double GetPrice()
        {
            return Quantity * Product.Price;  // Giá trị của OrderItem dựa vào số lượng và giá sản phẩm
        }
    }
}
