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
    public class totalNoFitForHumanConsumptionsController : Controller
    {
        private readonly thesisContext _context;

        public totalNoFitForHumanConsumptionsController(thesisContext context)
        {
            _context = context;
        }

        // GET: totalNoFitForHumanConsumptions
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.totalNoFitForHumanConsumptions.Include(t => t.Postmortem);
            return View(await thesisContext.ToListAsync());
        }

        // GET: totalNoFitForHumanConsumptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.totalNoFitForHumanConsumptions == null)
            {
                return NotFound();
            }

            var totalNoFitForHumanConsumptions = await _context.totalNoFitForHumanConsumptions
                .Include(t => t.Postmortem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalNoFitForHumanConsumptions == null)
            {
                return NotFound();
            }

            return View(totalNoFitForHumanConsumptions);
        }

        // GET: totalNoFitForHumanConsumptions/Create
        public IActionResult Create()
        {
            ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id");
            return View();
        }

        // POST: totalNoFitForHumanConsumptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Species,NoOfHeads,DressedWeight,PostmortemId")] totalNoFitForHumanConsumptions totalNoFitForHumanConsumptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalNoFitForHumanConsumptions);
                await _context.SaveChangesAsync();
                //   return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "SummaryAndDistributionOfMICs");
            }
            ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id", totalNoFitForHumanConsumptions.PostmortemId);
            return View();
        }

        // GET: totalNoFitForHumanConsumptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.totalNoFitForHumanConsumptions == null)
            {
                return NotFound();
            }

            var totalNoFitForHumanConsumptions = await _context.totalNoFitForHumanConsumptions.FindAsync(id);
            if (totalNoFitForHumanConsumptions == null)
            {
                return NotFound();
            }
            ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id", totalNoFitForHumanConsumptions.PostmortemId);
            return View(totalNoFitForHumanConsumptions);
        }

        // POST: totalNoFitForHumanConsumptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Species,NoOfHeads,DressedWeight,PostmortemId")] totalNoFitForHumanConsumptions totalNoFitForHumanConsumptions)
        {
            if (id != totalNoFitForHumanConsumptions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalNoFitForHumanConsumptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!totalNoFitForHumanConsumptionsExists(totalNoFitForHumanConsumptions.Id))
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
            ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id", totalNoFitForHumanConsumptions.PostmortemId);
            return View(totalNoFitForHumanConsumptions);
        }

        // GET: totalNoFitForHumanConsumptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.totalNoFitForHumanConsumptions == null)
            {
                return NotFound();
            }

            var totalNoFitForHumanConsumptions = await _context.totalNoFitForHumanConsumptions
                .Include(t => t.Postmortem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalNoFitForHumanConsumptions == null)
            {
                return NotFound();
            }

            return View(totalNoFitForHumanConsumptions);
        }

        // POST: totalNoFitForHumanConsumptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.totalNoFitForHumanConsumptions == null)
            {
                return Problem("Entity set 'thesisContext.totalNoFitForHumanConsumptions'  is null.");
            }
            var totalNoFitForHumanConsumptions = await _context.totalNoFitForHumanConsumptions.FindAsync(id);
            if (totalNoFitForHumanConsumptions != null)
            {
                _context.totalNoFitForHumanConsumptions.Remove(totalNoFitForHumanConsumptions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool totalNoFitForHumanConsumptionsExists(int id)
        {
            return (_context.totalNoFitForHumanConsumptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
