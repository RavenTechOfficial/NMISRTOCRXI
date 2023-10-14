using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Repositories;

namespace thesis.Controllers
{
    public class ChoroplethMapController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChoroplethMapController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Policy = "RequireSuperAdmin")]
		public IActionResult Index()
        {
            var res = _unitOfWork.ChroplethMap.GetChroplethData("Meat Sources");
            return View(res);
        }
		[HttpPost]
		public IActionResult ActionResult(string selectedOption)
		{
			ChroplethMapViewModel res;
			// Process selectedOption
			if (selectedOption == "Meat Sources")
			{
				res = _unitOfWork.ChroplethMap.GetChroplethData("Meat Sources");
			}
			else
			{
				res = _unitOfWork.ChroplethMap.GetChroplethData("Meat Distribution");
			}

			// Return appropriate view or redirect
			
			return View("Index", res);
		}
	}
}
