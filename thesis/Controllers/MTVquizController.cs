using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
	public class MTVquizController : Controller
	{
		[Authorize(Policy = "RequireMtvUsers")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
