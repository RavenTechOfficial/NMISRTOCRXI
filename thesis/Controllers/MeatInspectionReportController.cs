using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;

namespace thesis.Controllers
{
    public class MeatInspectionReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeatInspectionReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
