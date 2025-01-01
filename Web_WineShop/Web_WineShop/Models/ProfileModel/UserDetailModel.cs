using System.ComponentModel.DataAnnotations;


namespace Web_WineShop.Models.ProfileModel
{
	public class UserDetailModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Full Name is required.")]
		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		public string? Email { get; set; }

		[Required(ErrorMessage = "Date of Birth is required.")]
		[Display(Name = "Date of Birth")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Phone number is required.")]
		[Phone(ErrorMessage = "Invalid phone number.")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Address is required.")]
		[Display(Name = "Address")]
		public string ReceiveAddress { get; set; }
		public UserDetailModel() { }
		public UserDetailModel(int id, string fullName, string email, DateTime dateOfBirth, string phone, string receiveAddress)
		{
			Id = id;
			FullName = fullName;
			Email = email;
			DateOfBirth = dateOfBirth;
			Phone = phone;
			ReceiveAddress = receiveAddress;
		}
		public override string ToString()
		{
			return $"ID: {Id}, FullName: {FullName}, Email: {Email}, DateOfBirth: {DateOfBirth:yyyy-MM-dd}, Phone: {Phone}, ReceiveAddress: {ReceiveAddress}";
		}


	}
}
