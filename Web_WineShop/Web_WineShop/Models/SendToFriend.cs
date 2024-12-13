namespace Web_WineShop.Models
{
    public class SendToFriend
    {
        public string FriendName { get; set; }
        public string FriendEmail { get; set; }
        public string YourName { get; set; }
        public string YourEmail { get; set; }
        public string Message { get; set; }
        public string RecaptchaResponse { get; set; }
    }
}
