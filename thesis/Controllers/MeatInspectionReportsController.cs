using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Migrations;
using thesis.Models;

namespace thesis.Controllers
{
    //[Authorize(Policy = "RequireInspectorAdmin")]
    public class MeatInspectionReportsController : Controller
    {
        private readonly thesisContext _context;

        public MeatInspectionReportsController(thesisContext context)
        {
            _context = context;
        }

        // GET: MeatInspectionReports
        //public async Task<IActionResult> Index()
        //{
        //    var thesisContext = _context.MeatInspectionReports.Include(m => m.ReceivingReport);
        //    return View(await thesisContext.ToListAsync());
        //}
        public async Task<IActionResult> Index()
        {

            //var query = from mir in _context.MeatInspectionReports
            //            join rr in _context.ReceivingReports on mir.ReceivingReportId equals rr.Id
            //            join coi in _context.ConductOfInspections on mir.Id equals coi.MeatInspectionReportId
            //            join pfs in _context.PassedForSlaughters on coi.Id equals pfs.ConductOfInspectionId
            //            join pm in _context.Postmortems on pfs.Id equals pm.PassedForSlaughterId
            //            join tnfhc in _context.totalNoFitForHumanConsumptions on pm.Id equals tnfhc.PostmortemId
            //            join sdmics in _context.SummaryAndDistributionOfMICs on tnfhc.Id equals sdmics.TotalNoFitForHumanConsumptionId
            //            select new MeatInspectionReportViewModel
            //            {
            //                RecTime = rr.RecTime,
            //                Species = rr.Species,
            //                LiveWeight = rr.LiveWeight,
            //                MeatDealer = rr.MeatDealers.FirstName + ' ' + rr.MeatDealers.LastName, // Example assuming MeatDealer has a Name property
            //                Issue = (Data.Enum.Issue)coi.Issue,
            //                NoOfHeads = coi.NoOfHeads,
            //                Weight = coi.Weight,
            //                Cause = (Data.Enum.Cause)coi.Cause,
            //                NoOfHeadsPassed = pfs.NoOfHeads,
            //                WeightPassed = pfs.Weight,
            //                AnimalPart = (Data.Enum.AnimalPart)pm.AnimalPart,
            //                PostmortemCause = (Data.Enum.Cause)pm.Cause,
            //                PostmortemWeight = (int)pm.Weight,
            //                PostmortemNoOfHeads = (int)pm.NoOfHeads,
            //                Image1 = pm.Image1,
            //                Image2 = pm.Image2,
            //                Image3 = pm.Image3,
            //                // You can map Image1, Image2, and Image3 here if they are available in your models
            //                FitforConSpecies = tnfhc.Species,
            //                FitforConNoOfHeads = tnfhc.NoOfHeads,
            //                DressedWeight = tnfhc.DressedWeight,
            //                DestinationName = sdmics.DestinationName,
            //                DestinationAddress = sdmics.DestinationAddress,
            //                CertificateStatus = sdmics.CertificateStatus
            //            };

            //var inspectionReports = await query.ToListAsync();


            var res = _context.Results.ToList();
            return View(res);
        }


        // GET: MeatInspectionReports/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Id,RepDate,VerifiedByPOSMSHead,ReceivingReportId")] MeatInspectionReport meatInspectionReport)
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
            ViewData["ReceivingReportLabelText"] = _context.ReceivingReports.FirstOrDefault(r => r.Id == meatInspectionReport.ReceivingReportId)?.Id.ToString();

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

            var meatInspectionReport = await _context.MeatInspectionReports.FindAsync(id);
            if (meatInspectionReport == null)
            {
                return NotFound();
            }
            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);
            return View(meatInspectionReport);
        }

        // POST: MeatInspectionReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RepDate,VerifiedByPOSMSHead,ReceivingReportId")] MeatInspectionReport meatInspectionReport)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceivingReportId"] = new SelectList(_context.ReceivingReports, "Id", "Id", meatInspectionReport.ReceivingReportId);
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
                return Problem("Entity set 'thesisContext.MeatInspectionReports'  is null.");
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
