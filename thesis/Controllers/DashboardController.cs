using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Data.Enum;

namespace thesis.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
		private readonly thesisContext _context;

		public DashboardController(IUnitOfWork unitOfWork, thesisContext context)
        {
            _unitOfWork = unitOfWork;
			_context = context;
		}

        [Authorize(Policy = "RequireSuperAdmin")]
        public IActionResult Index()
        {
            var totalWeightModel = _unitOfWork.Dashboard.GetTotalOfMeatPerTimeSeries();
			var accountDetails = _context.MTVApplications.ToList();

			var dashboardViewModel = new DashboardViewModel
			{
				TotalWeightModel = totalWeightModel,
				AccountDetails = accountDetails
			};

			return View(dashboardViewModel);
        }
    }
}
