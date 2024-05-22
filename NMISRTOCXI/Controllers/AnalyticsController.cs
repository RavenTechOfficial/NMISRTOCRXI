using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using DomainLayer.Enum;

namespace NMISRTOCXI.Controllers
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

			List<Species> selectedSpecies = new List<Species>
			{
				Species.Hog
			};
			
			var analyticsViewModel = _unitOfWork.Analytics.GetTotalOfMeatPerTimeSeries("Monthly", selectedSpecies, startDateOfYear, currentDate);
			analyticsViewModel.HogBool = true;

			return View(analyticsViewModel);
        }
        [HttpPost]
        public IActionResult actionResult(AnalyticsViewModel analytics)
        {
			List<Species> selectedSpecies = new List<Species>();

			if (analytics.CattleBool) selectedSpecies.Add(Species.Cattle);
			if (analytics.CarabaoBool) selectedSpecies.Add(Species.Carabao);
			if (analytics.SwineBool) selectedSpecies.Add(Species.Swine);
			if (analytics.GoatBool) selectedSpecies.Add(Species.Goat);
			if (analytics.ChickenBool) selectedSpecies.Add(Species.Chicken);
			if (analytics.DuckBool) selectedSpecies.Add(Species.Duck);
			if (analytics.SheepBool) selectedSpecies.Add(Species.Sheep);
			if (analytics.HogBool) selectedSpecies.Add(Species.Hog);


			var analyticsViewModel = _unitOfWork.Analytics.GetTotalOfMeatPerTimeSeries(
				analytics.timeSeries,
				selectedSpecies,
				analytics.start,
				analytics.end);
			return View("Index", analyticsViewModel);
        }

    }
}