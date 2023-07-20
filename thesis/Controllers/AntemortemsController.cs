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
    public class AntemortemsController : Controller
    {
        private readonly thesisContext _context;

        public AntemortemsController(thesisContext context)
        {
            _context = context;
        }

        // GET: Antemortems
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.Antemortems.Include(a => a.MeatInspectionReport);
            return View(await thesisContext.ToListAsync());
        }

        // GET: Antemortems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Antemortems == null)
            {
                return NotFound();
            }

            var antemortem = await _context.Antemortems
                .Include(a => a.MeatInspectionReport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antemortem == null)
            {
                return NotFound();
            }

            return View(antemortem);
        }

        // GET: Antemortems/Create
        public IActionResult Create()
        {
            ViewData["MeatInspectionReportId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id");
            return View();
        }

        // POST: Antemortems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeatInspectionReportId")] Antemortem antemortem)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(antemortem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeatInspectionReportId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id", antemortem.MeatInspectionReportId);
            return View(antemortem);
        }

        // GET: Antemortems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Antemortems == null)
            {
                return NotFound();
            }

            var antemortem = await _context.Antemortems.FindAsync(id);
            if (antemortem == null)
            {
                return NotFound();
            }
            ViewData["MeatInspectionReportId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id", antemortem.MeatInspectionReportId);
            return View(antemortem);
        }

        // POST: Antemortems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeatInspectionReportId")] Antemortem antemortem)
        {
            if (id != antemortem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antemortem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntemortemExists(antemortem.Id))
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
            ViewData["MeatInspectionReportId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id", antemortem.MeatInspectionReportId);
            return View(antemortem);
        }

        // GET: Antemortems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Antemortems == null)
            {
                return NotFound();
            }

            var antemortem = await _context.Antemortems
                .Include(a => a.MeatInspectionReport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antemortem == null)
            {
                return NotFound();
            }

            return View(antemortem);
        }

        // POST: Antemortems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Antemortems == null)
            {
                return Problem("Entity set 'thesisContext.Antemortems'  is null.");
            }
            var antemortem = await _context.Antemortems.FindAsync(id);
            if (antemortem != null)
            {
                _context.Antemortems.Remove(antemortem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntemortemExists(int id)
        {
            return (_context.Antemortems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
