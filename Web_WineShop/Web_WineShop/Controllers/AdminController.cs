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

    }
}
