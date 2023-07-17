using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data.Enum;

namespace thesis.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        [Authorize(Policy = "RequireSuperAdmin")]
        public IActionResult Index()
        {
            var startDateOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var analyticsViewModel = _unitOfWork.Analytics.GetTotalOfMeatPerTimeSeries("Monthly", Species.Cattle, startDateOfYear, currentDate);
            return View(analyticsViewModel);
        }
        [HttpPost]
        public IActionResult actionResult(AnalyticsViewModel analytics)
        {
            var analyticsViewModel = _unitOfWork.Analytics.GetTotalOfMeatPerTimeSeries(
                analytics.timeSeries, 
                analytics.species, 
                analytics.start, 
                analytics.end);
            return View("Index", analyticsViewModel);
        }

    }
}
