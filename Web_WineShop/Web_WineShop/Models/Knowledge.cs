
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_WineShop.Models;

public class Knowledge

{
    [Key]
    [Column("ID_KNOWLEDGE")]
    public int IdKnowledge { get; set; }

    [Column("TITLE")]
    public string Title { get; set; }

    [Column("DESCRIPTION")]
    public string Description { get; set; }

    [Column("CATEGORY")]
    public string Category { get; set; }

    [Column("UPLOAD_DATE")]
    public DateTime UploadDate { get; set; }

    [Column("FILE_PATH")]
    public string FilePath { get; set; }
}




