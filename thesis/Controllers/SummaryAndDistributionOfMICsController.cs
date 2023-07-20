using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;
//using thesis.ViewModels;

namespace thesis.Controllers
{
    public class SummaryAndDistributionOfMICsController : Controller
    {
        private readonly thesisContext _context;

        public SummaryAndDistributionOfMICsController(thesisContext context)
        {
            _context = context;
        }

        // GET: SummaryAndDistributionOfMICs
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.SummaryAndDistributionOfMICs.Include(s => s.TotalNoFitForHumanConsumption);
            return View(await thesisContext.ToListAsync());
        }

        // GET: SummaryAndDistributionOfMICs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SummaryAndDistributionOfMICs == null)
            {
                return NotFound();
            }

            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs
                .Include(s => s.TotalNoFitForHumanConsumption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summaryAndDistributionOfMIC == null)
            {
                return NotFound();
            }

            return View(summaryAndDistributionOfMIC);
        }

        // GET: SummaryAndDistributionOfMICs/Create
        public IActionResult Create()
        {
            var viewModel = new SummaryViewModel
            {
                Summary = _context.SummaryAndDistributionOfMICs.Include(s => s.TotalNoFitForHumanConsumption).ToList(),
                // Populate any other necessary properties of the viewModel object
            };

            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id");
            return View(viewModel);
        }

        // POST: SummaryAndDistributionOfMICs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalNoFitForHumanConsumptionId,DestinationName,DestinationAddress,CertificateStatus")] SummaryAndDistributionOfMIC summaryAndDistributionOfMIC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summaryAndDistributionOfMIC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id", summaryAndDistributionOfMIC.TotalNoFitForHumanConsumptionId);
            return View(summaryAndDistributionOfMIC);
        }

        // GET: SummaryAndDistributionOfMICs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SummaryAndDistributionOfMICs == null)
            {
                return NotFound();
            }

            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs.FindAsync(id);
            if (summaryAndDistributionOfMIC == null)
            {
                return NotFound();
            }
            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id", summaryAndDistributionOfMIC.TotalNoFitForHumanConsumptionId);
            return View(summaryAndDistributionOfMIC);
        }

        // POST: SummaryAndDistributionOfMICs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalNoFitForHumanConsumptionId,DestinationName,DestinationAddress,CertificateStatus")] SummaryAndDistributionOfMIC summaryAndDistributionOfMIC)
        {
            if (id != summaryAndDistributionOfMIC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summaryAndDistributionOfMIC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummaryAndDistributionOfMICExists(summaryAndDistributionOfMIC.Id))
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
            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id", summaryAndDistributionOfMIC.TotalNoFitForHumanConsumptionId);
            return View(summaryAndDistributionOfMIC);
        }

        // GET: SummaryAndDistributionOfMICs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SummaryAndDistributionOfMICs == null)
            {
                return NotFound();
            }

            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs
                .Include(s => s.TotalNoFitForHumanConsumption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summaryAndDistributionOfMIC == null)
            {
                return NotFound();
            }

            return View(summaryAndDistributionOfMIC);
        }

        // POST: SummaryAndDistributionOfMICs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SummaryAndDistributionOfMICs == null)
            {
                return Problem("Entity set 'thesisContext.SummaryAndDistributionOfMICs'  is null.");
            }
            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs.FindAsync(id);
            if (summaryAndDistributionOfMIC != null)
            {
                _context.SummaryAndDistributionOfMICs.Remove(summaryAndDistributionOfMIC);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummaryAndDistributionOfMICExists(int id)
        {
            return (_context.SummaryAndDistributionOfMICs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
