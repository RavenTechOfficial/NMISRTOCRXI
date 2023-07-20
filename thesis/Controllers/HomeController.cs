using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using thesis.Models;

namespace thesis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated && User.IsInRole("SuperAdministrator"))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("InspectorAdministrator"))
            {
                return RedirectToAction("Index", "MeatEstablishments");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("MeatInspector"))
            {
                return RedirectToAction("Index", "ReceivingReports");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("MeatEstablishmentRepresentative"))
            {
                return RedirectToAction("Index", "ReceivingReports");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("MTVAdministrator"))
            {
                return RedirectToAction("Create", "MTVdashboard");
            }
            else
            {
				return View();
			}
			
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}