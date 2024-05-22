using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;

namespace NMISRTOCXI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
		private readonly AppDbContext _context;

		public DashboardController(IUnitOfWork unitOfWork, AppDbContext context)
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
