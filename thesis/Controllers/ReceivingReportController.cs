using Microsoft.AspNetCore.Mvc;
using thesis.Core.IRepositories;

namespace thesis.Controllers
{
    public class ReceivingReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReceivingReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var receivingReport = _unitOfWork.ReceivingReport.GetAllRReportsAsync();
            var totalHeads = _unitOfWork.ReceivingReport.GetTotalOfHeads();
            ViewBag.TotalHeads = totalHeads;
            return View();
        }
    }
}
