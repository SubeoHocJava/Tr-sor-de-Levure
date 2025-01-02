using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Models;
using Web_WineShop.Models.ProfileModel;

namespace Web_WineShop.Services
{
	public class ProfileService
	{
		private readonly AppDBContext _dbContex;

		public ProfileService(AppDBContext context)
		{
			_dbContex = context;
		}
		public bool UpdateInfor(UserDetailModel user)
		{
			User? u = _dbContex.Users.Find(user.Id);
			if (u != null)
			{
				u.Address = user.ReceiveAddress;
				u.Phone = user.Phone;
				u.DateOfBirth = user.DateOfBirth;
				u.FullName = user.FullName;
				_dbContex.Users.Update(u);
				_dbContex.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
