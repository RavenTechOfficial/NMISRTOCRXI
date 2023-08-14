using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class PassedForSlaughtersController : Controller
    {
        private readonly thesisContext _context;

        public PassedForSlaughtersController(thesisContext context)
        {
            _context = context;
        }

        // GET: PassedForSlaughters
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.PassedForSlaughters.Include(p => p.ConductOfInspection);
            return View(await thesisContext.ToListAsync());
        }

        // GET: PassedForSlaughters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PassedForSlaughters == null)
            {
                return NotFound();
            }

            var passedForSlaughter = await _context.PassedForSlaughters
                .Include(p => p.ConductOfInspection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passedForSlaughter == null)
            {
                return NotFound();
            }

            return View(passedForSlaughter);
        }

        // GET: PassedForSlaughters/Create
        public IActionResult Create()
        {
            int mostRecentId = _context.ConductOfInspections
                .OrderByDescending(c => c.Id)
                .Select(c => c.Id)
                .FirstOrDefault();

            var receivingReportIds = _context.MeatInspectionReports
                .Join(
                    _context.ConductOfInspections,
                    mir => mir.Id,
                    coi => coi.MeatInspectionReportId,
                    (mir, coi) => new { MeatInspectionReport = mir, ConductOfInspection = coi }
                )
                .Where(joinResult => joinResult.ConductOfInspection.Id == mostRecentId)
                .Select(joinResult => joinResult.MeatInspectionReport.ReceivingReportId)
                .ToList();

            // Retrieve the calculated differences for NoOfHeads and Weight using your queries
            var differencesNoOfHeads = _context.ReceivingReports
                .Join(
                    _context.MeatInspectionReports,
                    rr => rr.Id,
                    mir => mir.ReceivingReportId,
                    (rr, mir) => new { ReceivingNoOfHeads = rr.NoOfHeads, MeatInspectionReportsId = mir.Id }
                )
                .Join(
                    _context.ConductOfInspections,
                    rrmir => rrmir.MeatInspectionReportsId,
                    ci => ci.MeatInspectionReportId,
                    (rrmir, ci) => new { rrmir.ReceivingNoOfHeads, InspectionNoOfHeads = ci.NoOfHeads, PassedForSlaughter = rrmir.ReceivingNoOfHeads - ci.NoOfHeads }
                )
                .ToList();

            var differencesWeight = _context.ReceivingReports
                .Join(
                    _context.MeatInspectionReports,
                    rr => rr.Id,
                    mir => mir.ReceivingReportId,
                    (rr, mir) => new { LiveWeight = rr.LiveWeight, MeatInspectionReportsId = mir.Id }
                )
                .Join(
                    _context.ConductOfInspections,
                    rrmir => rrmir.MeatInspectionReportsId,
                    ci => ci.MeatInspectionReportId,
                    (rrmir, ci) => new { rrmir.LiveWeight, InspectionWeight = ci.Weight, PassedForSlaughterWeight = rrmir.LiveWeight - ci.Weight }
                )
                .ToList();

            int calculatedDifferenceNoOfHeads = differencesNoOfHeads.Select(result => result.PassedForSlaughter).Last();
            decimal calculatedDifferenceWeight = differencesWeight.Select(result => result.PassedForSlaughterWeight).Last();

            // Set the default values for the fields
            ViewData["ConductOfInspectionId"] = new SelectList(_context.ConductOfInspections, "Id", "Id", mostRecentId);
            ViewData["CalculatedDifferenceNoOfHeads"] = calculatedDifferenceNoOfHeads;
            ViewData["CalculatedDifferenceWeight"] = calculatedDifferenceWeight;

            return View();
        }


        // POST: PassedForSlaughters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoOfHeads,Weight,ConductOfInspectionId")] PassedForSlaughter passedForSlaughter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passedForSlaughter);
                await _context.SaveChangesAsync();
                //   return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "Postmortems");
            }
            ViewData["ConductOfInspectionId"] = new SelectList(_context.ConductOfInspections, "Id", "Id", passedForSlaughter.ConductOfInspectionId);
            return View(passedForSlaughter);
        }

        // GET: PassedForSlaughters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PassedForSlaughters == null)
            {
                return NotFound();
            }

            var passedForSlaughter = await _context.PassedForSlaughters.FindAsync(id);
            if (passedForSlaughter == null)
            {
                return NotFound();
            }
            ViewData["ConductOfInspectionId"] = new SelectList(_context.ConductOfInspections, "Id", "Id", passedForSlaughter.ConductOfInspectionId);
            return View(passedForSlaughter);
        }

        // POST: PassedForSlaughters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoOfHeads,Weight,ConductOfInspectionId")] PassedForSlaughter passedForSlaughter)
        {
            if (id != passedForSlaughter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passedForSlaughter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassedForSlaughterExists(passedForSlaughter.Id))
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
            ViewData["ConductOfInspectionId"] = new SelectList(_context.ConductOfInspections, "Id", "Id", passedForSlaughter.ConductOfInspectionId);
            return View(passedForSlaughter);
        }

        // GET: PassedForSlaughters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PassedForSlaughters == null)
            {
                return NotFound();
            }

            var passedForSlaughter = await _context.PassedForSlaughters
                .Include(p => p.ConductOfInspection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passedForSlaughter == null)
            {
                return NotFound();
            }

            return View(passedForSlaughter);
        }

        // POST: PassedForSlaughters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PassedForSlaughters == null)
            {
                return Problem("Entity set 'thesisContext.PassedForSlaughters'  is null.");
            }
            var passedForSlaughter = await _context.PassedForSlaughters.FindAsync(id);
            if (passedForSlaughter != null)
            {
                _context.PassedForSlaughters.Remove(passedForSlaughter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassedForSlaughterExists(int id)
        {
            return (_context.PassedForSlaughters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
