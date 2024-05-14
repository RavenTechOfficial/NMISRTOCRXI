using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace thesis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext _context;

		public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
			_context = context;
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
                return RedirectToAction("Index", "MTVdashboard");
            }
			else if (User.Identity.IsAuthenticated && User.IsInRole("MtvInspector"))
			{
				return RedirectToAction("Index", "MtvInspectorDashboard");
			}
			else if (User.Identity.IsAuthenticated && User.IsInRole("MtvUsers"))
			{
				return RedirectToAction("Create", "MTVapplication");
			}
			else 
            {
                var res = _context.PostArticles.ToList();
				return View(res);
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