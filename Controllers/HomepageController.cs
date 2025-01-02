using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Dao;
using Web_WineShop.Models;

namespace Web_WineShop.Controllers
{
    public class HomepageController : Controller
    {
        private readonly AppDBContext _dbContext;

        public HomepageController(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public IActionResult Homepage()
        {
            // Lấy danh sách các thương hiệu (giới hạn số lượng nếu cần)
            var brands = _dbContext.Brands
                .Select(b => new Brand
                {
                    Id = b.Id,
                    Name = b.Name,
                    ImageUrl = b.ImageUrl
                })
                .ToList();

            // Lấy danh sách các sản phẩm (giới hạn số lượng nếu cần)
            var products = _dbContext.Products
                .Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }).Take(4)
                .ToList();

            // Đưa dữ liệu vào ModelViewHomepage
            var viewModel = new ModelViewHomepage
            {
                Brands = brands,
                Products = products
            };

            // Trả dữ liệu về View
            return View(viewModel);
        }
    }
}
