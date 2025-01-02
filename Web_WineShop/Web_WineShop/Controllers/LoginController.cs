using Microsoft.AspNetCore.Identity;
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

        // DÙNG THƯ VIỆN HỖ TRỢ MÃ HÓA MK
        private readonly PasswordHasher<Account> _passwordHasher;

        public LoginController(AppDBContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
            _passwordHasher = new PasswordHasher<Account>();
        }

        //TRANG SAU ĐĂNG NHẬP
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

            // Ktra tạo khoá có bị BAN không
            if (account.Ban == true)
            {
                return Json(new { success = false, message = "Tài khoản của bạn đã bị cấm. Vui lòng liên hệ hỗ trợ." });
            }

            // Kiểm tra mật khẩu
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(account, account.Password, password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return Json(new { success = false, message = "Mật khẩu không chính xác. Vui lòng thử lại." });
            }

            TempData.Remove("EmailError");
            TempData.Remove("PasswordError");
            TempData.Remove("BanError");

            HttpContext.Session.SetInt32("accountSession", account.id);
            if (account.Role == 5) 
            { 
                return Json(new { success = true, redirectUrl = Url.Action("Admin", "Admin") }); 
            }
            return Json(new { success = true, redirectUrl = Url.Action("ProductList", "Product") });

        }

        // QUÊN MẬT KHẨU
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            // Kiểm tra email có tồn tại trong hệ thống không
            var account = await _context.Accounts.FirstOrDefaultAsync(u => u.Email == email);
            if (account == null)
            {
                return Json(new { success = false, message = "Email này không tồn tại trong hệ thống." });
            }

            // Tạo token reset mật khẩu
            var resetToken = Guid.NewGuid().ToString(); // Hoặc sử dụng một cách tạo token an toàn hơn

            // Tạo thông tin yêu cầu reset mật khẩu (bao gồm token và thời gian hết hạn)
            var resetRequest = new PasswordResetRequest
            {
                AccountId = account.id,
                Token = resetToken,
                ExpirationDate = DateTime.Now.AddHours(1) // Token hết hạn sau 1 giờ
            };
            _context.PasswordResetRequests.Add(resetRequest);
            await _context.SaveChangesAsync();

            // Mã hóa token để tránh các ký tự đặc biệt
            var encodedToken = Uri.EscapeDataString(resetToken);

            // Tạo URL reset mật khẩu (sử dụng https cố định)
            var resetLink = Url.Action(
                "ResetPassword",
                "Login",
                new { token = encodedToken },
                protocol: "https" // Đảm bảo sử dụng HTTPS thay vì HTTP
            );

            var emailContent = $"Để reset mật khẩu, vui lòng nhấp vào liên kết sau: <a href='{resetLink}' target='_blank'>Reset mật khẩu</a>";

            // Gửi email (giả sử bạn đã có EmailService)
            await _emailService.SendEmailAsync(email, "Yêu cầu reset mật khẩu", emailContent);

            return Json(new { success = true, message = "Đã gửi email reset mật khẩu. Vui lòng kiểm tra hộp thư của bạn." });
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

            // Mã hóa mật khẩu
            var hashedPassword = _passwordHasher.HashPassword(null, password); // Mã hóa mật khẩu

            // Tạo tài khoản mới
            var newAccount = new Account
            {
                Email = email,
                Password = hashedPassword,  // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
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

        // RESET MẬT KHẨU
        public IActionResult ResetPassword(string token)
        {
            // Kiểm tra token có hợp lệ và còn hạn sử dụng không
            var resetRequest = _context.PasswordResetRequests
                                       .FirstOrDefault(r => r.Token == token && r.ExpirationDate > DateTime.Now);

            if (resetRequest == null)
            {
                return RedirectToAction("Login", "Login"); // Token không hợp lệ hoặc hết hạn
            }

            // Gửi token tới View để người dùng có thể thay đổi mật khẩu
            return View(new ResetPasswordViewModel { Token = token });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resetRequest = _context.PasswordResetRequests
                    .FirstOrDefault(r => r.Token == model.Token && r.ExpirationDate > DateTime.Now);

                if (resetRequest == null)
                {
                    // Token không hợp lệ hoặc hết hạn
                    return RedirectToAction("Login", "Login");
                }

                // Lấy tài khoản liên quan tới yêu cầu reset mật khẩu
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.id == resetRequest.AccountId);
                if (account == null)
                {
                    return RedirectToAction("Login", "Login"); // Tài khoản không tồn tại
                }

                // Mã hóa mật khẩu mới
                var hashedPassword = _passwordHasher.HashPassword(account, model.Password);
                account.Password = hashedPassword;

                // Cập nhật mật khẩu mới vào cơ sở dữ liệu
                _context.Accounts.Update(account);
                _context.PasswordResetRequests.Remove(resetRequest);  // Xóa token sau khi sử dụng
                await _context.SaveChangesAsync();

                // Chuyển người dùng quay lại trang đăng nhập
                return RedirectToAction("Login", "Login");
            }

            // Nếu có lỗi validation
            return View(model);
        }


    }
}
