using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class TraceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly thesisContext _context;

        public TraceController(IUnitOfWork unitOfWork, thesisContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Results != null ?
                          View(await _context.Results.ToListAsync()) :
                          Problem("Entity set 'thesisContext.Results'  is null.");
        }
        //[HttpPost]
        //public IActionResult Index(string id)
        //{
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        var res = _context.Results.FirstOrDefault(p => p.uid == id);
        //        if (res != null)
        //        {
        //            return RedirectToAction("Result", new { uid = res.uid });
        //        }
        //    }
        //    return View();
        //}
        public async Task<IActionResult> Result(string? id, int? meatEstablishmentId)
        
        {

            var receivingReports = _context.ReceivingReports.ToList();
            var conductOfInspections = _context.ConductOfInspections.ToList();
            var passedForSlaughters = _context.PassedForSlaughters.ToList();
            var meatDealers = _context.MeatDealers.ToList();
            var meatInspectionReports = _context.MeatInspectionReports.ToList();
            var postmortem = _context.Postmortems.ToList();
            var totalNoFitForHumanConsumption = _context.totalNoFitForHumanConsumptions.ToList();
            var SummaryAndDistributionOfMICs = _context.SummaryAndDistributionOfMICs.ToList();

            ViewData["ReceivingReports"] = receivingReports;
            ViewData["ConductOfInspections"] = conductOfInspections;
            ViewData["PassedForSlaughters"] = passedForSlaughters;
            ViewData["MeatDealers"] = meatDealers;
            ViewData["meatInspectionReports"] = meatInspectionReports;
            ViewData["postmortem"] = postmortem;
            ViewData["totalNoFitForHumanConsumption"] = totalNoFitForHumanConsumption;
            ViewData["SummaryAndDistributionOfMICs"] = SummaryAndDistributionOfMICs;
            var concatenatedList = _context.Users
              .Join(
                  _context.MeatInspectionReports,
                  user => user.Id,
                  report => report.AccountDetailsId,
                  (user, report) => new SelectListItem
                  {
                      Value = user.Id.ToString(),
                      Text = $"{user.firstName} {user.lastName}"
                  })
              .ToList();

            ViewData["AccountDetailsId"] = new SelectList(concatenatedList, "Value", "Text");

            if (meatEstablishmentId.HasValue)
            {
                meatDealers = meatDealers.Where(dealer => dealer.MeatEstablishmentId == meatEstablishmentId.Value).ToList();
            }

            var meatEstablishments = _context.MeatEstablishment
            .Where(me => me.Name != null)
            .ToList();
            ViewData["MeatEstablishments"] = new SelectList(meatEstablishments, "Id", "Name");


            var thesisContext = _context.ReceivingReports
               .Include(r => r.AccountDetails)
               .Include(r => r.MeatDealers);



            if (id == null || _context.MeatInspectionReports == null)
            {
                return NotFound();
            }

            //var meatInspectionReport = await _context.MeatInspectionReports.FindAsync(id);
            var meatInspectionReport = _context.MeatInspectionReports.Where(p => p.UID == id).FirstOrDefault();


            //var meatInspectionReport = _context.MeatInspectionReports.Where(p => p.UID == id).FirstOrDefault();

            // Assuming UID is a unique identifier in your MeatInspectionReports table

            //var meatInspectionReport = await _context.MeatInspectionReports
            //    .Include(r => r.ReceivingReport)
            //    .ThenInclude(rr => rr.MeatDealers)
            //    .ThenInclude(md => md.MeatEstablishment)
            //    .FirstOrDefaultAsync(p => p.UID == id);

            //var meatInspectionReport = _context.MeatInspectionReports.Where(p => p.UID == id).FirstOrDefault();

            if (meatInspectionReport == null)
            {
                return NotFound();
            }

            // Create a MeatInspectionReportViewModel instance and populate its properties
            var viewModel = new MeatInspectionReportViewModel
            {
                Id = meatInspectionReport.Id,
                RepDate = meatInspectionReport.RepDate,
                AccountDetailsId = meatInspectionReport.AccountDetailsId,
                Address = meatInspectionReport.ReceivingReport.MeatDealers.MeatEstablishment.Address,
                LicenseToOperateNumber = meatInspectionReport.ReceivingReport.MeatDealers.MeatEstablishment.LicenseToOperateNumber,
                MeatEstablishment = meatInspectionReport.ReceivingReport.MeatDealers.MeatEstablishment.Name,
                VerifiedBy = meatInspectionReport.VerifiedByPOSMSHead,
                Specie = meatInspectionReport.ReceivingReport.Species,
                UID = meatInspectionReport.UID


            };

            var result = new Result
            {

            };

            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);

            // Pass the viewModel to the view
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SubmitRating([FromBody] FeedbackResultViewModel feedVM)

        {

            var result = new Feedback();

            switch (feedVM.NumberOfStarsClicked)
            {
                case 1:
                    result.HighlyDissatisfied += 1;
                    break;
                case 2:
                    result.Dissatisfied += 1;
                    break;
                case 3:
                    result.Neutral += 1;
                    break;
                case 4:
                    result.Satisfied += 1;
                    break;
                case 5:
                    result.HighlySatisfied += 1;
                    break;
            }

            _context.Add(result);
            _context.SaveChanges();

            return RedirectToAction("Result", "Trace");
        }
    }
}
