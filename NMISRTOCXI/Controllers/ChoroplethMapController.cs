using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using NMISRTOCXI.Repositories;

namespace NMISRTOCXI.Controllers
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
			res.MeatSourcesBool = true;
            return View(res);
        }
		[HttpPost]
		public IActionResult ActionResult(ChroplethMapViewModel selectedOption)
		{
			
			// Process selectedOption
			if (selectedOption.MeatSourcesBool)
			{
				selectedOption = _unitOfWork.ChroplethMap.GetChroplethData("Meat Sources");
			}
			else
			{
				selectedOption = _unitOfWork.ChroplethMap.GetChroplethData("Meat Distribution");
			}

			// Return appropriate view or redirect
			
			return View("Index", selectedOption);
		}
	}
}
