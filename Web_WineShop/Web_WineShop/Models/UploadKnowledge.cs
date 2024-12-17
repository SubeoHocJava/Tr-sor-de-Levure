using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_WineShop.Models
{
    public class UploadKnowledge
    {
		public int IdKnowledge { get; set; } 
		public string Title { get; set; } 
		public string Description { get; set; } // Mô tả bài báo
		public string Category { get; set; } // Phân loại bài báo
		public DateTime UploadDate { get; set; } // Ngày upload bài báo
		public string FilePath { get; set; } // Đường dẫn lưu file bài báo
		public IFormFile File { get; set; } // Tệp tin upload chỉ để xử lý
	}
}
