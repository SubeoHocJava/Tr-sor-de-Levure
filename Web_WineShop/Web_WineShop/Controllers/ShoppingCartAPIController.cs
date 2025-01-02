using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Web_WineShop.Dao;
using Web_WineShop.Models;

namespace Web_WineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartAPIController : Controller
    {
        private readonly AppDBContext _context;
        public ShoppingCartAPIController(AppDBContext context) { _context = context; }
        [HttpGet("{id_User}")]
        public ActionResult<ShoppingCart> GetShoppingCart(int id_User)
        {
            List<CartItem> list = _context.CartItems.Where(ci => ci.User_ID == id_User).Include(ci => ci.Product).ToList();
            if (list == null || !list.Any())
            {
                return NotFound();
            }
            ShoppingCart shoppingCart = new ShoppingCart(list);
            return Ok(shoppingCart);
        }
    }
}