namespace Web_WineShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string Describe { get; set; }

        public DateTime CreationDate { get; set; }

        public string Status { get; set; }

        // Quan hệ đệ quy
        public Category ParentCategory { get; set; } // Category cha
        public ICollection<Category> SubCategories { get; set; } // Danh sách Category con

        public ICollection<Product> Products { get; set; }
    }
}
