using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Data;

namespace thesis.Controllers
{
	public class MTVInspectorRegistrationStatusController : Controller
	{
		private readonly thesisContext _context;

        public MTVInspectorRegistrationStatusController(thesisContext context)
        {
			_context = context;
		}
		[Authorize(Policy = "RequireMtvInspector")]
		public async Task<IActionResult> IndexAsync()
		{
			var res = await _context.MTVApplications.Include(ve => ve.Vehicle).ToListAsync();
			return View(res);
		}
	}
}
