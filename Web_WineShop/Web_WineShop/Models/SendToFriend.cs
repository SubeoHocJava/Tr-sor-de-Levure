namespace Web_WineShop.Models
{
    public class SendToFriend
    {   
        public int Id { get; set; }  
        public string YourEmail { get; set; }        
        public string FriendEmail { get; set; }        
        public string FriendName { get; set; } 
        public string Message { get; set; }  
        public string RecaptchaResponse { get; set; }
    }
}
