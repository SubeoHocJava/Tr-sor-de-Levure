using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    [Table("SEND_TO_FRIEND")]
    public class SendToFriend
    {
        [Key]
        public int Id { get; set; }

        [Column("FRIEND_NAME")]
        [Required(ErrorMessage = "Friend's name is required")]
        public string FriendName { get; set; }

        [Column("FRIEND_EMAIL")]
        [Required(ErrorMessage = "Friend's email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string FriendEmail { get; set; }

        [Column("YOUR_NAME")]
        [Required(ErrorMessage = "Your name is required")]
        public string YourName { get; set; }

        [Column("YOUR_EMAIL")]
        [Required(ErrorMessage = "Your email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string YourEmail { get; set; }

        [Column("MESSAGE")]
        public string Message { get; set; }
    }
}
