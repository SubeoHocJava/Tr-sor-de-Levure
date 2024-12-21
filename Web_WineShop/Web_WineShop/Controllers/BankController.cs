using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Dao;

namespace Web_WineShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BankController : ControllerBase
	{
		private readonly AppDBContext _context;

		public BankController(AppDBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var banks = _context.Banks.Select(b => new { b.Id, b.Name }).ToList();
			return Ok(banks);
		}
	}
}
