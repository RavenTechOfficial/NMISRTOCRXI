using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
using System.Data;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Models;

namespace thesis.Controllers
{
    //[Authorize(Policy = "RequireInspectorAdmin")]

    public class MeatInspectionReportsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AccountDetails> _userManager;

        public MeatInspectionReportsController(AppDbContext context, UserManager<AccountDetails> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MeatInspectionReports
        //public async Task<IActionResult> Index()
        //{
        //    var AppDbContext = _context.MeatInspectionReports.Include(m => m.ReceivingReport);
        //    return View(await AppDbContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(int? meatEstablishmentId)
        {
            var meatEstablishments = _context.MeatEstablishment
                .Where(me => me.Name != null)
                .ToList();
            ViewData["MeatEstablishments"] = new SelectList(meatEstablishments, "Id", "Name");

            var monthlyreportsInfo = MonthlyReports();

            // Sort the reportsInfo list by CreatedAt in descending order
            var sortedReportsInfos = monthlyreportsInfo.OrderByDescending(item => item.DateInspected).ToList();

            return View(sortedReportsInfos);

        }

        public List<MeatInspectionReportViewModel> MonthlyReports()
        {
            //var monthlyreportsInfo = (from mir in _context.MeatInspectionReports
            //                          join rr in _context.ReceivingReports on mir.ReceivingReportId equals rr.Id
            //                          join ai in _context.ConductOfInspections on mir.Id equals ai.MeatInspectionReportId
            //                          join ps in _context.PassedForSlaughters on ai.Id equals ps.ConductOfInspectionId
            //                          join pi in _context.Postmortems on ps.Id equals pi.PassedForSlaughterId
            //                          join tn in _context.TotalNoFitForHumanConsumptions on pi.Id equals tn.PostmortemId
            //                          join sd in _context.SummaryAndDistributionOfMICs on tn.Id equals sd.TotalNoFitForHumanConsumptionId
            //                          join md in _context.MeatDealers on rr.MeatDealersId equals md.Id
            //                          join au in _context.Users on mir.AccountDetailsId equals au.Id
            //                          join me in _context.MeatEstablishment on md.MeatEstablishmentId equals me.Id
            //                          select new MeatInspectionReportViewModel
            //                          {
            //                              MeatInspectionReportId = mir.Id,
            //                              DateReceived = rr.RecTime,
            //                              NoOfHeads = rr.NoOfHeads,
            //                              Origin = rr.Origin,
            //                              Specie = rr.Species,
            //                              ReceivingReportId = rr.Id,
            //                              AntemortemId = rr.Id,
            //                              PassedId = ps.Id,
            //                              PostmortemId = pi.Id,
            //                              TotalNoId = tn.Id,
            //                              SummaryId = sd.Id,
            //                              Issue = ai.Issue,
            //                              AnimalPart = pi.AnimalPart,
            //                              piCause = pi.Cause,
            //                              piNoOfHeads = pi.NoOfHeads,
            //                              piWeight = pi.Weight,
            //                              tnNoOfHeads = tn.NoOfHeads,
            //                              tnDressedWeight = tn.DressedWeight,
            //                              DestinationName = sd.DestinationName,
            //                              DestinationAddress = sd.DestinationAddress,
            //                              MICIssued = sd.MICIssued,
            //                              MICCancelled = sd.MICCancelled,
            //                              Weight = ai.Weight,
            //                              Cause = ai.Cause,
            //                              MeatDealer = md.FirstName + " " + md.LastName,
            //                              MeatEstablishment = me.Name,
            //                              LicenseToOperateNumber = me.LicenseToOperateNumber,
            //                              MeatEstablishmentAddress = me.Address,
            //                              DateInspected = mir.RepDate,
            //                              MeatInspector = au.firstName + " " + au.lastName,
            //                              VerifiedBy = mir.VerifiedByPOSMSHead
            //                          })
            //        .ToList<MeatInspectionReportViewModel>();

            return null;
        }


        public async Task<IActionResult> Generate()
        {
            var res = _context.Results.ToList();
            return View(res);
        }
        public async Task<IActionResult> DailyInspection()
        {
            var meatEstablishments = _context.MeatEstablishment
                .Where(me => me.Name != null)
                .ToList();
            ViewData["MeatEstablishments"] = new SelectList(meatEstablishments, "Id", "Name");

            var reportsInfo = GetReports();

            // Sort the reportsInfo list by CreatedAt in descending order
            var sortedReportsInfo = reportsInfo.OrderByDescending(item => item.DateInspected).ToList();

            return View(sortedReportsInfo);
        }

        public List<MeatInspectionReportViewModel> GetReports()
        {
            //var reportsInfo = (from mir in _context.MeatInspectionReports
            //                   join rr in _context.ReceivingReports on mir.ReceivingReportId equals rr.Id
            //                   join md in _context.MeatDealers on rr.MeatDealersId equals md.Id
            //                   join au in _context.Users on mir.AccountDetailsId equals au.Id
            //                   join me in _context.MeatEstablishment on md.MeatEstablishmentId equals me.Id
            //                   select new MeatInspectionReportViewModel
            //                   {
            //                       MeatInspectionReportId = mir.Id,
            //                       DateReceived = rr.RecTime,
            //                       Specie = rr.Species,
            //                       MeatDealer = md.FirstName + " " + md.LastName,
            //                       MeatEstablishment = me.Name,
            //                       DateInspected = mir.RepDate,
            //                       MeatInspector = au.firstName + " " + au.lastName,
            //                       VerifiedBy = mir.VerifiedByPOSMSHead,
            //                       UID = mir.UID,
            //                   })
            //        .ToList();

            return null;
        }

        public async Task<IActionResult> DailyIndex(Guid? id, Guid? meatEstablishmentId)
        {
            var receivingReports = _context.ReceivingReports.ToList();
            var conductOfInspections = _context.ConductOfInspections.ToList();
            var passedForSlaughters = _context.PassedForSlaughters.ToList();
            var meatDealers = _context.MeatDealers.ToList();
            var meatInspectionReports = _context.MeatInspectionReports.ToList();
            var postmortem = _context.Postmortems.ToList();
            var totalNoFitForHumanConsumption = _context.TotalNoFitForHumanConsumptions.ToList();
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


            var AppDbContext = _context.ReceivingReports
               .Include(r => r.AccountDetails)
               .Include(r => r.MeatDealers);







            if (id == null || _context.MeatInspectionReports == null)
            {
                return NotFound();
            }

            var meatInspectionReport = await _context.MeatInspectionReports.FindAsync(id);

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
                UID = meatInspectionReport.UID,

            };


            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);

            // Pass the viewModel to the view
            return View(viewModel);
        }

        // GET: MeatInspectionReports/Create
        public IActionResult Create()
        {
            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id");
            return View();
        }

        // POST: MeatInspectionReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RepDate,VerifiedByPOSMSHead,ReceivingReportId,AccountDetailsId")] MeatInspectionReport meatInspectionReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meatInspectionReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If there was a validation error, populate the ViewData with the actual ReceivingReportId values
            //  ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);
            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);
           // ViewData["ReceivingReportLabelText"] = _context.ReceivingReports.FirstOrDefault(r => r.Id == meatInspectionReport.ReceivingReportId)?.Id.ToString();

            // return View(meatInspectionReport);
            return RedirectToAction("Create", "ConductOfInspections", new { meatInspectionReportId = meatInspectionReport.ReceivingReportId });
        }

        // GET: MeatInspectionReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeatInspectionReports == null)
            {
                return NotFound();
            }
            //var loggedInUserId = _userManager.GetUserId(User);
            //ViewData["VerifiedBy"] = loggedInUserId;
            var meatInspectionReport = await _context.MeatInspectionReports.FindAsync(id);
            if (meatInspectionReport == null)
            {
                return NotFound();
            }
            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);

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
            return View(meatInspectionReport);
        }

        // POST: MeatInspectionReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RepDate,VerifiedByPOSMSHead,ReceivingReportId,AccountDetailsId")] MeatInspectionReport meatInspectionReport)
        {
            if (id != meatInspectionReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meatInspectionReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeatInspectionReportExists(meatInspectionReport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DailyInspection));
            }
            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);
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
            return View(meatInspectionReport);
        }

        // GET: MeatInspectionReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeatInspectionReports == null)
            {
                return NotFound();
            }

            var meatInspectionReport = await _context.MeatInspectionReports
                .Include(m => m.ReceivingReport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meatInspectionReport == null)
            {
                return NotFound();
            }

            return View(meatInspectionReport);
        }

        // POST: MeatInspectionReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeatInspectionReports == null)
            {
                return Problem("Entity set 'AppDbContext.MeatInspectionReports'  is null.");
            }
            var meatInspectionReport = await _context.MeatInspectionReports.FindAsync(id);
            if (meatInspectionReport != null)
            {
                _context.MeatInspectionReports.Remove(meatInspectionReport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeatInspectionReportExists(int id)
        {
            return (_context.MeatInspectionReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }




    }
}
