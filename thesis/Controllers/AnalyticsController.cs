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
            var analyticsViewModel = _unitOfWork.Analytics.GetTotalOfMeatPerTimeSeries();
            return View(analyticsViewModel);
        }



    }
}
