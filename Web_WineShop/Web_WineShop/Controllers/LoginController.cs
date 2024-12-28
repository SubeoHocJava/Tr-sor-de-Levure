using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using Web_WineShop.Dao;
using Web_WineShop.Models;
using Web_WineShop.Services;

namespace Web_WineShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDBContext _context;
        private readonly EmailService _emailService;


        public LoginController(AppDBContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // TRANG SAU ĐĂNG NHẬP
        public IActionResult ProductDetails()
        {
            return View();
        }

        // ĐĂNG NHẬP
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var account = _context.Accounts
                                  .FirstOrDefault(u => u.Email == email);

            if (account == null)
            {
                return Json(new { success = false, message = "Email chưa được đăng ký trong hệ thống. Vui lòng kiểm tra lại." });
            }

            // Ktra tao khoan co bi BAN ko
            if (account.Ban == true)
            {
                return Json(new { success = false, message = "Tài khoản của bạn đã bị cấm. Vui lòng liên hệ hỗ trợ." });
            }

            if (account.Password != password)
            {
                return Json(new { success = false, message = "Mật khẩu không chính xác. Vui lòng thử lại." });
            }

            TempData.Remove("EmailError");
            TempData.Remove("PasswordError");
            TempData.Remove("BanError");

            HttpContext.Session.SetInt32("accountSession", account.id);

            return Json(new { success = true, redirectUrl = Url.Action("ProductDetails") });
        }


        // QUÊN MẬT KHẨU
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, message = "Vui lòng nhập địa chỉ email hợp lệ." });
            }

            var account = _context.Accounts.FirstOrDefault(u => u.Email == email);
            if (account == null)
            {
                return Json(new { success = false, message = "Email này chưa được đăng ký. Vui lòng kiểm tra lại." });
            }

            // CÒN CHỈNH SỬA, MẬT KHẨU KO NÊN GỬI TRỰC TIẾP QUA MAIL
            var subject = "MẬT KHẨU TR-SOR-DE-LEVURE";
            var body = $"<p>Hello {account.Email},</p><p>Mật khẩu của bạn là: {account.Password}</p><p>Nếu bạn không yêu cầu điều này, vui lòng bỏ qua email này.</p>";

            try
            {
                await _emailService.SendEmailAsync(email, subject, body);
                return Json(new { success = true, message = "Mật khẩu đã được gửi đến email của bạn." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Gửi email thất bại. Vui lòng thử lại." });
            }
        }

        // ĐĂNG KÍ
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string fullName, DateTime dob, string gender, string email, string phone, string country, string password, string passwordConfirm)
        {
            // Kiểm tra các trường thông tin không được để trống
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirm))
            {
                return Json(new { success = false, message = "Bạn cần nhập đầy đủ thông tin. Vui lòng kiểm tra lại." });
            }

            // Kiểm tra đủ 18 tuổi
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age)) age--; 
            if (age < 18)
            {
                return Json(new { success = false, message = "Bạn chưa đủ tuổi để sử dụng dịch vụ." });
            }

            // Kiểm tra mật khẩu và mật khẩu xác nhận có khớp?
            if (password != passwordConfirm)
            {
                return Json(new { success = false, message = "Mật khẩu không trùng khớp. Vui lòng kiểm tra lại." });
            }

            // Kiểm tra email đã tồn tại chưa
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(u => u.Email == email);
            if (existingAccount != null)
            {
                return Json(new { success = false, message = "Email đã được đăng ký. Vui lòng kiểm tra lại." });
            }

            // Tạo tài khoản mới
            var newAccount = new Account
            {
                Email = email,
                Password = password,  // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                createDate = DateTime.Now,
                Role = 0,
                Ban = false
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();

            // Tạo thông tin người dùng
            var newUser = new User
            {
                FullName = fullName,
                DateOfBirth = dob,
                Gender = gender,
                Phone = phone,
                Country = country,
                Account = newAccount
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Trả về thông báo thành công và URL chuyển hướng
            return Json(new { success = true, message = "Đăng ký thành công!", redirectUrl = Url.Action("Login", "Login") });
        }


        // Hàm mã hóa mật khẩu
        //private string HashPassword(string password)
        //{
        //    // Sử dụng thuật toán PBKDF2 để mã hóa mật khẩu
        //    var salt = new byte[16];
        //    using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(salt);
        //    }

        //    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: password,
        //        salt: salt,
        //        prf: KeyDerivationPrf.HMACSHA256,
        //        iterationCount: 10000,
        //        numBytesRequested: 256 / 8
        //    ));

        //    return hashed;
        //}

    }
}
