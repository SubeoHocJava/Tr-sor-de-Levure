using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;

using System.Linq;
using Web_WineShop.Dao;

namespace Web_WineShop.Controllers
{
	public class WhiskyController : Controller
	{
		private readonly AppDBContext _context;

		public WhiskyController(AppDBContext context)
		{
			_context = context;
		}

		public IActionResult Whisky()
		{
			// Lấy danh sách sản phẩm Whisky
			var products = _context.Products
				.Include(p => p.Brand)
				.Include(p => p.Detail)
				.Include(p => p.Category)
				.Where(p => p.Category.Name == "Whisky")
				.Select(p => new
				{
					p.Id,
					p.Name,
					p.Price,
					p.ImageUrl,
					p.Detail.Size
				})
				.ToList();

			// Lấy danh sách thương hiệu (Brand)
			var brands = _context.Brands
				.Where(b => b.Products.Any(p => p.Category.Name == "Whisky"))
				.Select(b => b.Name)
				.Distinct()
				.ToList();

			// Lấy danh sách nồng độ (ABV)
			var abvs = _context.Details
				.Where(d => d.Products.Any(p => p.Category.Name == "Whisky"))
				.Select(d => d.ABV)
				.Distinct()
				.OrderBy(abv => abv)
				.ToList();

			// Lấy danh sách dung tích (Size)
			var sizes = _context.Details
				.Where(d => d.Products.Any(p => p.Category.Name == "Whisky"))
				.Select(d => d.Size)
				.Distinct()
				.OrderBy(size => size)
				.ToList();

			// Lấy giá trị lớn nhất của giá sản phẩm
			var maxPrice = _context.Products
				.Where(p => p.Category.Name == "Whisky")
				.Max(p => p.Price);

			// Truyền dữ liệu vào ViewBag
			ViewBag.Brands = brands;
			ViewBag.ABVs = abvs;
			ViewBag.Sizes = sizes;
			ViewBag.MaxPrice = maxPrice;

			return View(products);
		}

		[HttpGet]
		[Route("/Whisky/FilterProducts")]
		public IActionResult FilterProducts(string? brand, double? abv, string? size)
		{
			try
			{
				Console.WriteLine($"[DEBUG] Brand: {brand ?? "NULL"}, ABV: {abv?.ToString() ?? "NULL"}, Size: {size ?? "NULL"}");

				// Xây dựng query cơ bản với điều kiện Whisky
				var query = from p in _context.Products
							join b in _context.Brands on p.BrandId equals b.Id
							join d in _context.Details on p.DetailsId equals d.Id
							join c in _context.Categories on p.CategoryId equals c.Id
							where c.Name == "Whisky" // Điều kiện Category là Whisky
							&& (string.IsNullOrWhiteSpace(brand) || b.Name == brand)
							&& (!abv.HasValue || d.ABV == abv.Value)
							&& (string.IsNullOrEmpty(size) || d.Size == size)

							select new
							{
								p.Id,
								p.Name,
								p.Price,
								p.ImageUrl,
								d.Size,
								BrandName = b.Name,
								d.ABV
							};
				// In ra kết quả query để debug
				Console.WriteLine($"Filtered Products Count: {query.Count()}");
				foreach (var product in query)
				{
					Console.WriteLine($"Product: {product.Name}, Brand: {product.BrandName}, Size: {product.Size}");
				}

				// Lấy danh sách sản phẩm đã lọc
				var filteredProducts = query.ToList();
				Console.WriteLine(filteredProducts[0].Name);
				// Trả về dữ liệu dưới dạng JSON
				return Json(new { data = filteredProducts });
			}
			catch (Exception ex)
			{
				// Ghi lại lỗi vào log
				Console.WriteLine($"Lỗi khi lọc sản phẩm: {ex.Message}");
				return Json(new { error = "Đã có lỗi xảy ra trong việc lọc sản phẩm!" });
			}
		}

	}
}
