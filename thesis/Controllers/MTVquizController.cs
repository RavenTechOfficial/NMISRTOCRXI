using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
	public class MTVquizController : Controller
	{
		[Authorize(Policy = "RequireMTVAdmin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
