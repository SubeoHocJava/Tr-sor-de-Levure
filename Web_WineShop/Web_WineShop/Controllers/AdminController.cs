// AdminController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Models;

namespace Web_WineShop.Controllers
{
	public class AdminController : Controller
	{
		private readonly AppDBContext _context;

		public AdminController(AppDBContext context)
		{
			_context = context;
		}

		// GET: Admin/Index
		public async Task<IActionResult> Admin()
		{
			var users = await _context.Users.Include(u => u.Account).ToListAsync();
			return View(users);
		}

		// GET: Admin/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var user = await _context.Users.Include(u => u.Account)
				.FirstOrDefaultAsync(u => u.Id == id);
			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

        // POST: Admin/Edit/5
        [HttpPost]
        public IActionResult Edit(int userId, string userFullName, String phone, string userEmail, Boolean userBan, int userRole, int userPoints)
        {
            var user = _context.Users.Include(u => u.Account).FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.FullName = userFullName;
                user.Phone = phone;
                user.Account.Email = userEmail;
                user.Account.Ban = userBan;
                user.Account.Role = userRole;  // Cập nhật Role
                user.Points = userPoints;  // Cập nhật Points

                _context.SaveChanges();
            }

            return RedirectToAction("Admin");

        }
        // POST: Admin/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // Kiểm tra người dùng có tồn tại trong cơ sở dữ liệu không
            var user = await _context.Users.Include(u => u.Account).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();  // Nếu không tìm thấy người dùng, trả về lỗi 404
            }

            // Xóa tài khoản nếu có
            if (user.Account != null)
            {
                _context.Accounts.Remove(user.Account);  // Xóa tài khoản liên kết
            }

            // Xóa người dùng
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu

            return RedirectToAction("Admin");  // Sau khi xóa, quay lại trang Admin
        }



    }
}
