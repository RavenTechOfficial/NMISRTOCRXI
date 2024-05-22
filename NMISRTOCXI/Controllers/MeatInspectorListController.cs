using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NMISRTOCXI.Controllers
{
    public class MeatInspectorListController : Controller
    {
        [Authorize(Policy = "RequireSuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
