using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NMISRTOCXI.Controllers
{
    public class RegisteredMTVController : Controller
    {
        [Authorize(Policy = "RequireMTVAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
