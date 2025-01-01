using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Web_WineShop.Dao;
using Web_WineShop.Models;
using static Web_WineShop.Models.WishItem;

namespace Web_WineShop.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDBContext _dbContext;

        public WishlistController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Wishlist));
        }

        // Hiển thị wishlist của người dùng
        public IActionResult Wishlist()
        {
            var userId = 1; // Lấy User ID hiện tại (giả định)
            var wishItems = _dbContext.WishItems
                .Include(w => w.Product)
                .Where(w => w.UserId == userId)
                .ToList();

            var model = new WishlistViewModel // Tạo đối tượng ViewModel chứa danh sách WishItems
            {
                WishItems = wishItems
            };

            return View(model); // Trả về ViewModel cho view
        }

        [HttpPost]
        public IActionResult AddToWishlist(int productId)
        {
            var userId = 1; // Lấy User ID hiện tại
            var product = _dbContext.Products.Find(productId);

            if (product != null)
            {
                var existingItem = _dbContext.WishItems
                    .FirstOrDefault(w => w.UserId == userId && w.ProductId == productId);

                if (existingItem == null)
                {
                    var wishItem = new WishItem
                    {
                        UserId = userId,
                        ProductId = productId
                    };
                    _dbContext.WishItems.Add(wishItem);
                    _dbContext.SaveChanges();
                }
            }

            return RedirectToAction("Wishlist");
        }

        // Hiển thị form gửi wishlist qua email
        [HttpGet]
        public IActionResult SendToFriend()
        {
            var model = new SendToFriend(); // Khởi tạo model trống cho form
            return View(model); // Trả về view SendToFriend.cshtml
        }

        // Gửi wishlist qua email
        [HttpPost]
        public async Task<IActionResult> SendToFriend(SendToFriend model)
        {
            if (ModelState.IsValid)
            {
                // Lấy User ID hiện tại
                var userId = 1; // Giả định là người gửi có UserId là 1
                var wishItems = _dbContext.WishItems
                    .Include(w => w.Product)
                    .Where(w => w.UserId == userId)
                    .ToList();

                // Nội dung email gửi cho người nhận
                string emailSubjectForFriend = $"{model.YourName} has shared their wishlist with you!";
                string emailBodyForFriend = $"Hello {model.FriendName},\n\n{model.YourName} has shared their wishlist with you:\n\n";

                foreach (var item in wishItems)
                {
                    emailBodyForFriend += $"{item.Product.Name} - {item.Product.Price:C}\n";
                }

                emailBodyForFriend += $"\nMessage from {model.YourName}: {model.Message}\n\nBest regards,\nYour Wine Shop";

                // Nội dung email gửi cho người gửi (bạn)
                string emailSubjectForSender = "Your Wishlist has been sent!";
                string emailBodyForSender = $"Hello {model.YourName},\n\nYour wishlist has been successfully shared with {model.FriendName}:\n\n";

                foreach (var item in wishItems)
                {
                    emailBodyForSender += $"{item.Product.Name} - {item.Product.Price:C}\n";
                }

                emailBodyForSender += $"\nMessage from {model.YourName}: {model.Message}\n\nBest regards,\nYour Wine Shop";

                // Gửi email cho người nhận
                bool emailSentToFriend = await SendEmailAsync(model.FriendEmail, emailSubjectForFriend, emailBodyForFriend);

                // Gửi email cho người gửi (bạn)
                bool emailSentToSender = await SendEmailAsync(model.YourEmail, emailSubjectForSender, emailBodyForSender);

                if (emailSentToFriend && emailSentToSender)
                {
                    // Lưu thông tin chia sẻ vào cơ sở dữ liệu với lớp SendToFriend
                    var sendToFriend = new SendToFriend
                    {
                        YourName = model.YourName,
                        YourEmail = model.YourEmail,
                        FriendName = model.FriendName,
                        FriendEmail = model.FriendEmail,
                        Message = model.Message
                    };

                    // Lưu danh sách món đồ vào cơ sở dữ liệu (tạo thêm logic cho phần này nếu cần)
                    foreach (var item in wishItems)
                    {
                        // Tạo một mục mới trong cơ sở dữ liệu nếu cần
                        // Bạn có thể lưu thông tin chi tiết sản phẩm vào một bảng khác, nếu cần thiết
                    }

                    _dbContext.SendToFriends.Add(sendToFriend); // Thêm vào cơ sở dữ liệu
                    await _dbContext.SaveChangesAsync(); // Lưu thay đổi
                    ViewData["Message"] = "Wishlist sent successfully to both parties and saved to the database!";
                }
                else
                {
                    ViewData["Message"] = "There was an error sending the wishlist.";
                }

                return View(model); // Trả về form với thông báo
            }

            return View(model); // Nếu có lỗi, hiển thị lại form
        }


        // Xóa sản phẩm khỏi wishlist
        [HttpPost]
        public IActionResult RemoveFromWishlist(int wishItemId)
        {
            var userId = 1; // Lấy User ID hiện tại
            var wishItem = _dbContext.WishItems
                .FirstOrDefault(w => w.Id == wishItemId && w.UserId == userId);

            if (wishItem != null)
            {
                _dbContext.WishItems.Remove(wishItem);
                _dbContext.SaveChanges();
                return Json(new { success = true, message = "Item removed successfully!" });
            }

            return Json(new { success = false, message = "Item not found!" });
        }
        [HttpPost]
        public IActionResult PurchaseWishlist()
        {
            // Lấy User ID hiện tại (giả sử giá trị là 1 để test, cần thay đổi logic khi triển khai thực tế)
            var userId = 1;

            // Lấy tất cả các sản phẩm trong Wishlist của người dùng hiện tại
            var wishItems = _dbContext.WishItems
                .Where(w => w.UserId == userId)
                .ToList();

            if (wishItems == null || !wishItems.Any())
            {
                return Json(new { success = false, message = "Không có sản phẩm nào trong Wishlist!" });
            }

            foreach (var item in wishItems)
            {
                // Tìm sản phẩm trong giỏ hàng hiện tại của người dùng
                var existingCartItem = _dbContext.CartItems
                    .FirstOrDefault(c => c.User_ID == userId && c.ProductId == item.ProductId);

                if (existingCartItem != null)
                {
                    // Nếu sản phẩm đã có trong giỏ hàng, chỉ cần tăng số lượng
                    existingCartItem.Quantity += 1;
                }
                else
                {
                    // Nếu sản phẩm chưa có, thêm mới vào giỏ hàng
                    var cartItem = new CartItem
                    {
                        User_ID = userId,
                        ProductId = item.ProductId,
                        Quantity = 1, // Mặc định số lượng là 1
                    };

                    _dbContext.CartItems.Add(cartItem);
                }
            }

            // Xóa toàn bộ các sản phẩm trong Wishlist sau khi thêm vào giỏ hàng
            _dbContext.WishItems.RemoveRange(wishItems);

            // Lưu các thay đổi vào cơ sở dữ liệu
            _dbContext.SaveChanges();

            return Json(new { success = true, message = "Các sản phẩm trong Wishlist đã được thêm vào giỏ hàng!" });
        }


        // Hàm gửi email
        private async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("lydung853@gmail.com", "gqms exqg wowt rlsy"),
                    EnableSsl = true,
                };

                var mailMessage = new System.Net.Mail.MailMessage("lydung853@gmail.com", toEmail, subject, body);
                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}