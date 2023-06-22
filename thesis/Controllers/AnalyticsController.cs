using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
