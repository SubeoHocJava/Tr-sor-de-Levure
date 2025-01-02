using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Web_WineShop.Dao;
using Web_WineShop.Models;
using Web_WineShop.Models.Admin;

namespace Web_WineShop.Controllers
{
	public class AdminController : Controller
	{
		private readonly AppDBContext _context;
		private readonly HttpClient _httpClient;
		public AdminController(AppDBContext context, HttpClient httpClient)
		{
			_context = context;
			_httpClient = httpClient;
		}
		public IActionResult Admin()
		{
			return View();
		}
		public IActionResult VoucherManagement()
		{
			var vouchers = _context.Vouchers.ToList();
			var model = new ModelViewVoucher(vouchers);
			return PartialView("ManageVoucherView", model);
		}
		public ActionResult UserManagement()
		{
			var users = _context.Users.Select(u => new UserManagementViewModel
			{
				Id = u.Id,
				FullName = u.FullName,
				Phone = u.Phone,
				Email = u.Account.Email,
				Ban = u.Account.Ban,
				Role = u.Account.Role,
				Points = u.Points
			}).ToList();

			return PartialView("UserManagementPartial", users);
		}
		[HttpGet]
		public IActionResult PendingOrders()
		{
			var model = new List<PendingOrdersModel>();
			var listOrder = _context.Orders
				.Where(o => o.Details.Dates.Any(d => d.State.Id == 4))
				.Include(o => o.Details)
				.ThenInclude(od => od.Dates)
				.ThenInclude(od => od.State)
				.Include(o => o.User)
				.ThenInclude(u => u.Account)
				.ToList();
			var orderDetails = _context.OrderDetails
				.Include(od => od.Items)
				.ThenInclude(oi => oi.Product)
				.ToDictionary(od => od.Id);
			foreach (var item in listOrder)
			{
				orderDetails.TryGetValue(item.Id, out var itemDetail);
				item.Details.Items = itemDetail.Items;
			}
			foreach (var order in listOrder)
			{
				PendingOrdersModel p = new PendingOrdersModel();
				model.Add(p);
				p.OrderDate = order.Details.Dates.ElementAt(0).Date;
				p.Items = order.Details.Items;
				p.CustomerEmail = order.User.Account.Email;
				p.CustomerName = order.User.FullName;
				p.TotalAmount = order.TotalAmount;
			}
			return PartialView("_PendingOrdersview", model);
		}
	}
}
