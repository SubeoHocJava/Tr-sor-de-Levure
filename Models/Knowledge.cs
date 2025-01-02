using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("KNOWLEDGE")]
    public class Knowledge
    {
        [Key]
        [Column("ID_KNOWLEDGE")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("TITLE")]
        public string Title { get; set; }

        [MaxLength(1000)]
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [MaxLength(255)]
        [Column("CATEGORY")]
        public string Category { get; set; }

        [Column("UPLOAD_DATE")]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(500)]
        [Column("FILE_PATH")]
        public string FilePath { get; set; }
    }
}
