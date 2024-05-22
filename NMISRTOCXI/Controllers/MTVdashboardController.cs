using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;

namespace NMISRTOCXI.Controllers
{
	public class MTVdashboardController : Controller
	{
		private readonly AppDbContext _context;
		
		public MTVdashboardController(AppDbContext context)
		{
			_context = context;
		}
		[Authorize(Policy = "RequireMTVAdmin")]
		public async Task<IActionResult> IndexAsync()
		{
			var users = await _context.Users.ToListAsync();
			var checklist = await _context.CheckLists.ToListAsync();
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
