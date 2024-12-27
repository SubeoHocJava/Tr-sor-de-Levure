using System.Data;
using System.Security.Cryptography.Pkcs;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_WineShop.Dao;
using Web_WineShop.Models;

namespace Web_WineShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BankApiController : ControllerBase
	{
		private readonly AppDBContext _context;

		public BankApiController(AppDBContext context)
		{
			_context = context;
		}
		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var banks = _context.Banks.ToList();
			return Ok(banks);
		}
		[HttpPost("Exist")]
		public IActionResult Exist([FromBody] JsonElement data)
		{
			if (data.ValueKind == JsonValueKind.Null)
			{
				return NotFound("Bank account not found.");
			}
			int idBank = data.GetProperty("idBank").GetInt32();
			long accountNo = data.GetProperty("no").GetInt64();
			Console.WriteLine(idBank + " " + accountNo);
			BankAccount? exist = _context.BankAccounts.FirstOrDefault(ba => ba.BankId == idBank && ba.AccountNo == accountNo);
			if (exist != null) return Ok(exist);
			return NotFound("Bank account not found.");
		}

	}
}
