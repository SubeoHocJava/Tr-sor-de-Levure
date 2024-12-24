using System.ComponentModel.DataAnnotations;

namespace Web_WineShop.Models.ProfileModel
{
	public class UserDetailModel
	{
		public int Id { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }
		[Required]
		public string Phone { get; set; }
		[Required]
		public string ReceiveAddress { get; set; }

		public UserDetailModel(int id, string fullName, string email, DateTime dateOfBirth, string phone, string receiveAddress)
		{
			Id = id;
			FullName = fullName;
			Email = email;
			DateOfBirth = dateOfBirth;
			Phone = phone;
			ReceiveAddress = receiveAddress;
		}
	}
}
