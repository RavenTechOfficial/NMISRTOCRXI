using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
	[Authorize(Policy = "RequireInspectorAdmin")]
	public class ReceivingReportsController : Controller
    {
        private readonly thesisContext _context;

        public ReceivingReportsController(thesisContext context)
        {
            _context = context;
        }

        // GET: ReceivingReports
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.ReceivingReports.Include(r => r.MeatDealers);
            return View(await thesisContext.ToListAsync());
        }

        // GET: ReceivingReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReceivingReports == null)
            {
                return NotFound();
            }

            var receivingReport = await _context.ReceivingReports
                .Include(r => r.MeatDealers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receivingReport == null)
            {
                return NotFound();
            }

            return View(receivingReport);
        }

        // GET: ReceivingReports/Create
        public IActionResult Create()
        {
            ViewData["MeatDealersId"] = new SelectList(_context.MeatDealers, "Id", "Id");
            ViewData["ReceivingId"] = new SelectList(_context.Receivings, "Id", "Id");
            return View();
        }

        // POST: ReceivingReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecTime,BatchCode,Species,Category,NoOfHeads,LiveWeight,MeatDealersId,Origin,ShippingDoc,HoldingPenNo,ReceivingBy,ReceivingId")] ReceivingReport receivingReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receivingReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeatDealersId"] = new SelectList(_context.MeatDealers, "Id", "Id", receivingReport.MeatDealersId);
            return View(receivingReport);
        }

        // GET: ReceivingReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReceivingReports == null)
            {
                return NotFound();
            }

            var receivingReport = await _context.ReceivingReports.FindAsync(id);
            if (receivingReport == null)
            {
                return NotFound();
            }
            ViewData["MeatDealersId"] = new SelectList(_context.MeatDealers, "Id", "Id", receivingReport.MeatDealersId);
            return View(receivingReport);
        }

        // POST: ReceivingReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecTime,BatchCode,Species,Category,NoOfHeads,LiveWeight,MeatDealersId,Origin,ShippingDoc,HoldingPenNo,ReceivingBy,ReceivingId")] ReceivingReport receivingReport)
        {
            if (id != receivingReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receivingReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceivingReportExists(receivingReport.Id))
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
            ViewData["MeatDealersId"] = new SelectList(_context.MeatDealers, "Id", "Id", receivingReport.MeatDealersId);
            return View(receivingReport);
        }

        // GET: ReceivingReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReceivingReports == null)
            {
                return NotFound();
            }

            var receivingReport = await _context.ReceivingReports
                .Include(r => r.MeatDealers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receivingReport == null)
            {
                return NotFound();
            }

            return View(receivingReport);
        }

        // POST: ReceivingReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReceivingReports == null)
            {
                return Problem("Entity set 'thesisContext.ReceivingReports'  is null.");
            }
            var receivingReport = await _context.ReceivingReports.FindAsync(id);
            if (receivingReport != null)
            {
                _context.ReceivingReports.Remove(receivingReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceivingReportExists(int id)
        {
          return (_context.ReceivingReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
