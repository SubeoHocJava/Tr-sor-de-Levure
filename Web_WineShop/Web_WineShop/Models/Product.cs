using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
	[Table("PRODUCT")]
	public class Product
	{
		[Key]
		[Column("ID")]  // Set column name for ID
		public int Id { get; set; }

		[Required]
		[Column("BrandId")]  // Set column name for BrandId
		public int BrandId { get; set; }

		[ForeignKey("BrandId")]
		public virtual Brand Brand { get; set; }

		[Required]
		[Column("DetailsId")]
		public int DetailsId { get; set; }

		[ForeignKey("DetailsId")]
		public virtual Detail Detail { get; set; }

		[Required]
		[Column("CategoryId")]  // Set column name for CategoryId
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

		[Required]
		[MaxLength(255)]
		[Column("ProductName")]
		public string Name { get; set; }

		[MaxLength(500)]
		[Column("ProductImageUrl")]
		public string ImageUrl { get; set; }

		[Column("ProductAppreciation")]
		public string Appreciation { get; set; }


		[MaxLength(50)]
		[Column("ProductStatus")]
		public string Status { get; set; }

		[Column("Price")]
		public double Price { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }

    }
}

