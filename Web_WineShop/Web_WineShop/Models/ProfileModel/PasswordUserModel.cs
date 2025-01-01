using System.ComponentModel.DataAnnotations;

namespace Web_WineShop.Models.ProfileModel
{
	public class PasswordUserModel
	{
		[Required(ErrorMessage = "Current password is required.")]
		[DataType(DataType.Password)]
		public string Password {  get; set; }
		[Required(ErrorMessage = "New password is required.")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }
		[Required(ErrorMessage = "Confirm password is required.")]
		[DataType(DataType.Password)]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		public PasswordUserModel(string password, string newPassword, string confirmPassword)
		{
			Password = password;
			NewPassword = newPassword;
			ConfirmPassword = confirmPassword;
		}

		public PasswordUserModel()
		{
		}
	}
}
