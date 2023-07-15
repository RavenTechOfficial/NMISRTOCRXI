using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data.Enum;

namespace thesis.Controllers
{
    public class GeolocationController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;

		public GeolocationController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

        [Authorize(Policy = "RequireSuperAdmin")]
		public IActionResult Index(GeolocationViewModel geolocationData)
		{
			var geolocationResult = _unitOfWork.Geolocation.Getgeolocation(geolocationData);
			return View(geolocationResult);
		}

		[HttpPost]
		public IActionResult ProcessData(GeolocationViewModel geolocationData)
		{
			var geolocationResult = _unitOfWork.Geolocation.Getgeolocation(geolocationData);
			return View("Index", geolocationResult);
		}
	}
}
