using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using DomainLayer.Models;

namespace NMISRTOCXI.Controllers
{
	public class MTVquizController : Controller
	{
		private readonly AppDbContext _context;

		public MTVquizController(AppDbContext context)
        {
			_context = context;
		}
        [Authorize(Policy = "RequireMtvUsers")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SavePercentage(double percentage)
		{
			

			var application = _context.MTVApplications.OrderBy(p => p.Id).LastOrDefault();

			var ifpercentage = (percentage < 75) ? PassOrFail.Fail : PassOrFail.Pass;

			var res = new MTVquiz
			{
				MTVApplication = application,
				passorfail = ifpercentage,
			};

			_context.Add(res);
			_context.SaveChanges();

			return Json(new { success = true, message = "Percentage saved successfully." });
		}
	}

	
}
