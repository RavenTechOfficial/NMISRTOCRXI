using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
