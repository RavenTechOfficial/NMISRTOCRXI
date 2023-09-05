using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class ChoroplethMapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
