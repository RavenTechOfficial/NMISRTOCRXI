using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
