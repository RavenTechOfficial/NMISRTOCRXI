using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;

namespace thesis.Controllers
{
	public class UsersManagementController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public UsersManagementController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public IActionResult Index()
		{
			var users = _unitOfWork.UsersManangement.GetAllUsersAsync();
			return View(users);
		}

		public IActionResult Details()
		{
			return View();
		}

		public IActionResult Edit()
		{
			return View();
		}

		public IActionResult Delete()
		{
			return View();
		}

	}
}
