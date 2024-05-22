using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NMISRTOCXI.Controllers
{
	public class MTVuserController : Controller
	{
		[Authorize(Policy = "RequireSuperAdmin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
