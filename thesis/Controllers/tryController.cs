using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class tryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Trys(string uid)
        {
            ViewData["uid"] = uid;
            return View();
        }
    }
}
