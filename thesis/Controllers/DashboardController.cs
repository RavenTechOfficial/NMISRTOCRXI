using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;
using DomainLayer.Models.ViewModels;
using thesis.Data;
using DomainLayer.Enum;

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
            var feedbacks = _unitOfWork.Feedback.GetFeedbacks();

			var dashboardViewModel = new DashboardViewModel
			{
				TotalWeightModel = totalWeightModel,
				AccountDetails = accountDetails,
                Feedbacks = feedbacks
               
			};

			return View(dashboardViewModel);
        }
        public IActionResult InspectorAdminDashboard()
        {
            var totalWeightModel = _unitOfWork.Dashboard.GetTotalOfMeatPerTimeSeries();
			var accountDetails = _context.MTVApplications.ToList();
            var feedbacks = _unitOfWork.Feedback.GetFeedbacks();

			var dashboardViewModel = new DashboardViewModel
			{
				TotalWeightModel = totalWeightModel,
				AccountDetails = accountDetails,
                Feedbacks = feedbacks
               
			};

			return View(dashboardViewModel);
        }
    }
}
