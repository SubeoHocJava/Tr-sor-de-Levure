using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;

namespace Web_WineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;

        public ProductController(AppDBContext context)
        {
            _context = context;
        }
     
        public async Task<IActionResult> ProductList()
        {
            var products = await _context.Products.ToListAsync(); // Fetch all products
            return View(products); // Pass products to the view
        }

        // Phương thức chính để hiển thị chi tiết sản phẩm
        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound(); // 404
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Detail)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // 404
            }

            return View("ProductDetails", product);
        }

        // New action to load product details dynamically via AJAX
        [HttpGet]
        public async Task<IActionResult> LoadProductDetails(string viewType, int productId)
        {
            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Detail)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return NotFound(); // 404
            }

            if (viewType == "description")
            {
                var descriptionHtml = $"<p>{product.Detail.Description}</p>";                                   
                return Json(new { descriptionHtml });
            }
            else if (viewType == "details")
            {
                var detailsHtml = $@"
                    <table class='custom-table w-100'>
                        <thead>
                            <tr>
                                <th>Attribute</th>
                                <th>Value</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr><td><b>Brand</b></td><td>{product.Brand.Name}</td></tr>
                            <tr><td><b>Country</b></td><td>{product.Brand.Country}</td></tr>
                            <tr><td><b>Size</b></td><td>{product.Detail.Size}</td></tr>
                            <tr><td><b>ABV</b></td><td>{product.Detail.ABV}%</td></tr>
                            <tr><td><b>Age</b></td><td>{product.Detail.Age} Year Old</td></tr>
                            <tr><td><b>Varietal</b></td><td>{product.Detail.Varietal}</td></tr>
                            <tr><td><b>Status</b></td><td>{product.Status}</td></tr>
                        </tbody>
                    </table>";

                return Json(new { detailsHtml });
            }

            return BadRequest();
        }
    }
}
