using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_WineShop.Models
{
    public class SendToFriend
    {
        [Key]
        public int Id { get; set; }

        [Column("FRIEND_NAME")]
        public string FriendName { get; set; }

        [Column("FRIEND_EMAIL")]
        public string FriendEmail { get; set; }

        [Column("YOUR_NAME")]
        public string YourName { get; set; }

        [Column("YOUR_EMAIL")]
        public string YourEmail { get; set; }

        [Column("MESSAGE")]
        public string Message { get; set; }

        [Column("RECAPTCHA_RESPONSE")]
        public string RecaptchaResponse { get; set; }
    }
}