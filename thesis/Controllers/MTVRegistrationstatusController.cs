using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Data;

namespace thesis.Controllers
{
    public class MTVRegistrationstatus : Controller
    {
		private readonly thesisContext _context;

		public MTVRegistrationstatus(thesisContext context)
		{
			_context = context;
		}
		[Authorize(Policy = "RequireMTVAdmin")]
		public async Task<IActionResult> IndexAsync()
		{
			var res = await _context.MTVApplications.ToListAsync();
			return View(res);
		}
	}
}
