using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace thesis.Controllers
{
    public class RegisterAccountController : Controller
    {
        [Authorize(Policy = "RequireSuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
