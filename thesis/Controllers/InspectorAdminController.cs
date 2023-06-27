using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class InspectorAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
