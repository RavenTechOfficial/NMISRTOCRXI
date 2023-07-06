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
        public ActionResult Index()
        {
            var model = new AnalyticsViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AnalyticsViewModel model)
        {
            // Retrieve the selected values from the model
            //Species selectedSpecies = model.SelectedSpecies;
            //string selectedTimeSeries = model.SelectedTimeSeries;

            //var total = _unitOfWork.Analytics.GetAnalytics(selectedSpecies, selectedTimeSeries);
            //var dates = _unitOfWork.Analytics.GetDates(selectedSpecies, selectedTimeSeries);

            //var eachTime = new List<string>();

            //if (selectedTimeSeries == "Weekly")
            //{
            //    eachTime = new List<string>() { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            //}
            //else if (selectedTimeSeries == "Yearly")
            //{
            //    eachTime = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            //}
            //else
            //{
            //    // Assuming you want to generate a list of years dynamically
            //    int startYear = 2019;
            //    int endYear = DateTime.Now.Year; // Get the current year dynamically

            //    eachTime = Enumerable.Range(startYear, endYear - startYear + 1).Select(year => year.ToString()).ToList();
            //}



            //var dressedWeightByDay = new Dictionary<string, int>();         
            //foreach (var day in eachTime)
            //{
            //    dressedWeightByDay[day] = 0;
            //}
          
            //for (var i = 0; i < total.Count; i++)
            //{
            //    var dayOfWeek = dates[i];
            //    dressedWeightByDay[dayOfWeek] = total[i];
            //}
            //model.DressedWeight = dressedWeightByDay.Values.ToList();
            //model.Dates = dressedWeightByDay.Keys.ToList();

            return View();
        }

        //[Authorize(Policy = "RequireSuperAdmin")]
        public ActionResult Result()
        {
            // Show the result page
            return View();
        }

    }
}
