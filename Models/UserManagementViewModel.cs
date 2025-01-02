using System.ComponentModel.DataAnnotations;

namespace Web_WineShop.Models
{
    public class UserManagementViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool Ban { get; set; } // Assuming 'Ban' is a boolean type.

        public int Role { get; set; }

        public int Points { get; set; }
    }
}
