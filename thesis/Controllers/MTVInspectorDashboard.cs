using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Data;

namespace thesis.Controllers
{
	public class MTVInspectorDashboard : Controller
	{
		private readonly thesisContext _context;
		public MTVInspectorDashboard(thesisContext context)
        {
			_context = context;
		}
        [Authorize(Policy = "RequireMtvInspector")]
		public async Task<IActionResult> IndexAsync()
		{
			var users = await _context.Users.ToListAsync();
			var checklist = await _context.checklists.ToListAsync();
			var payment = await _context.Payments.Include(p => p.MTVApplication).ToListAsync();

			var mtvdashboardViewModel = new MtvDashboardViewModel
			{
				AccountDetails = users,
				Checklists = checklist,
				Payments = payment
			};

			return View(mtvdashboardViewModel);
		}
	}
}
