using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thesis.Data;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Controllers
{
	public class MTVquizController : Controller
	{
		private readonly thesisContext _context;

		public MTVquizController(thesisContext context)
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

			var ifpercentage = (percentage < 75) ? passorfail.Fail : passorfail.Pass;

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
