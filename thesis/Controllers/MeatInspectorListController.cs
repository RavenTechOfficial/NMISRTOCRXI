using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class MeatInspectorListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
