using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Data;

namespace thesis.Controllers
{
	public class MTVdashboard : Controller
	{
		private readonly thesisContext _context;
		
		public MTVdashboard(thesisContext context)
		{
			_context = context;
		}
		[Authorize(Policy = "RequireMTVAdmin")]
		public async Task<IActionResult> IndexAsync()
		{
			var res = await _context.Users.ToListAsync();
			return View(res);
		}
	}
}
