using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace NMISRTOCXI.Controllers
{
    public class TraceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;

        public TraceController(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Results != null ?
                          View(await _context.Results.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Results'  is null.");
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
        public async Task<IActionResult> Result(string? id, Guid? meatEstablishmentId)

        {

            //         if (id == null || !_context.MeatInspectionReports.Any())
            //         {
            //             return NotFound();
            //         }
            //         var meatInspectionReport = await _context.MeatInspectionReports
            //             .Include(m => m.ReceivingReport)
            //                 .ThenInclude(rr => rr.MeatDealers)
            //                 .ThenInclude(md => md.MeatEstablishment)

            //             .FirstOrDefaultAsync(m => m.UID == id);

            //         if (meatInspectionReport == null)
            //         {
            //             return NotFound();
            //         }

            //var summary = await _context.SummaryAndDistributionOfMICs
            //      .Include(p => p.TotalNoFitForHumanConsumption)
            //         .ThenInclude(p => p.Postmortem)
            //         .ThenInclude(p => p.PassedForSlaughter)
            //         .ThenInclude(p => p.ConductOfInspection)
            //         //.ThenInclude(p => p.MeatInspectionReport)
            //         //.Where(p => p.TotalNoFitForHumanConsumption.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.UID == id) // Use the 'id' parameter to filter
            //         .FirstOrDefaultAsync();

            //var totalfit = await _context.TotalNoFitForHumanConsumptions
            //	.Include(p => p.Postmortem)
            //	   .ThenInclude(p => p.PassedForSlaughter)
            //	   .ThenInclude(p => p.ConductOfInspection)
            //	   //.ThenInclude(p => p.MeatInspectionReport)
            //	   //.Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.UID == id) // Use the 'id' parameter to filter
            //	   .FirstOrDefaultAsync();


            //List<MeatDealers> meatDealers = new List<MeatDealers>();
            //         if (meatEstablishmentId.HasValue)
            //         {
            //             meatDealers = await _context.MeatDealers
            //                 .Where(dealer => dealer.MeatEstablishmentId == meatEstablishmentId.Value)
            //                 .ToListAsync();
            //         }


            //         var viewModel = new ResultViewModel
            //         {
            //             Id = meatInspectionReport.Id,
            //             AccountDetailsId = meatInspectionReport.AccountDetailsId,
            //             VerifiedBy = meatInspectionReport.VerifiedByPOSMSHead,
            //             Specie = meatInspectionReport.ReceivingReport.Species,
            //             Category = meatInspectionReport.ReceivingReport.Category,
            //             ReceivingBy = meatInspectionReport.ReceivingReport.ReceivingBy,
            //             RecTime = meatInspectionReport.ReceivingReport.RecTime,
            //             LiveWeight = meatInspectionReport.ReceivingReport.LiveWeight,
            //             NoOfHeads = meatInspectionReport.ReceivingReport.NoOfHeads,
            //             RepDate = meatInspectionReport.RepDate,
            //             RepHeads = totalfit.NoOfHeads,
            //             DressedWeight = totalfit.DressedWeight,
            //             //CertificateStatus = summary.CertificateStatus,
            //             origin = meatInspectionReport.ReceivingReport.Origin,
            //             MeatDealerFName = meatInspectionReport.ReceivingReport.MeatDealers.FirstName,
            //             MeatDealerMName = meatInspectionReport.ReceivingReport.MeatDealers.MiddleName,
            //             MeatDealerLName = meatInspectionReport.ReceivingReport.MeatDealers.LastName,
            //             MeatDealerAddress = meatInspectionReport.ReceivingReport.MeatDealers.Address,
            //             MeatDealerContactNo = meatInspectionReport.ReceivingReport.MeatDealers.ContactNo,
            //             Address = meatInspectionReport.ReceivingReport.MeatDealers.MeatEstablishment.Address,
            //             UID = meatInspectionReport.UID,
            //             MeatEstablishmentLTO = meatInspectionReport.ReceivingReport.MeatDealers.MeatEstablishment.LicenseToOperateNumber,
            //             MeatEstablishmentName = meatInspectionReport.ReceivingReport.MeatDealers.MeatEstablishment.Name,
            //             MeatEstablishmentAddress = meatInspectionReport.ReceivingReport.MeatDealers.MeatEstablishment.Address,
            //             ShippingDocuments = meatInspectionReport.ReceivingReport.ShippingDoc,

            //         };

            //         ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);
            return View();
            //return View(viewModel);
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
