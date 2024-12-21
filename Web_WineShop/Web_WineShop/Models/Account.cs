using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web_WineShop.Models;

public class Account
{
    [Key]
    [Column("ID")]
    public int id { get; set; }

    [ForeignKey("User")]
    [Column("USER_ID")]
    public int UserId { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    [Column("EMAIL")]
    public string Email { get; set; }

    [Required]
    [Column("PASSWORD")]
    public string Password { get; set; }

    [Column("CREATE_DATE")]
    public DateTime createDate { get; set; }

    [Column("ROLE")]
    public int Role { get; set; }

    [Column("BAN")]
    public bool Ban { get; set; }

    public virtual User User { get; set; }
    public virtual List<Violate> Violates { get; set; }
}
