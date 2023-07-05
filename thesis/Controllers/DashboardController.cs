using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;
using thesis.Data.Enum;

namespace thesis.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Policy = "RequireSuperAdmin")]
        public IActionResult Index(Species? selectedSpecies)
        {
            var species = selectedSpecies ?? Species.Cattle;
            var totalWeightModel = _unitOfWork.Dashboard.GetTotalOfMeatPerTimeSeries(species);
            return View(totalWeightModel);
        }
    }
}
