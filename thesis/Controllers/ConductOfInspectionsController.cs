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

namespace thesis.Controllers
{
    public class ConductOfInspectionsController : Controller
    {
        private readonly thesisContext _context;

        public ConductOfInspectionsController(thesisContext context)
        {
            _context = context;
        }

        // GET: ConductOfInspections
        public async Task<IActionResult> Index(string myVariable)
        {
            ViewBag.MyVariable = myVariable;

            var viewModel = new ConductOfInspectionViewModel();
            viewModel.ConductOfInspections = await _context.ConductOfInspections.Include(c => c.Antemortem).ToListAsync();
            ViewData["AntemortemId"] = new SelectList(_context.Antemortems, "Id", "Id");

            return View("Index", viewModel.ConductOfInspections); ; // Pass the list of ConductOfInspection objects to the view
        }

        // GET: ConductOfInspections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConductOfInspections == null)
            {
                return NotFound();
            }

            var conductOfInspection = await _context.ConductOfInspections
                .Include(c => c.Antemortem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductOfInspection == null)
            {
                return NotFound();
            }

            return View(conductOfInspection);
        }

        // GET: ConductOfInspections/Create
        public IActionResult Create()
        {
            var viewModel = new ConductOfInspectionViewModel();
            viewModel.ConductOfInspections = new List<ConductOfInspection>(); // Initialize the list
            viewModel.SingleConductOfInspection = new ConductOfInspection();

            ViewData["AntemortemId"] = new SelectList(_context.Antemortems, "Id", "Id");

            return View(viewModel);
        }

        // POST: ConductOfInspections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Issue,NoOfHeads,Weight,Cause,AntemortemId")] ConductOfInspection conductOfInspection)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(conductOfInspection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new ConductOfInspectionViewModel();
            viewModel.ConductOfInspections = await _context.ConductOfInspections.Include(c => c.Antemortem).ToListAsync();
            viewModel.SingleConductOfInspection = new ConductOfInspection();
            viewModel.Issue = conductOfInspection.Issue; // Initialize the Issue property

            ViewData["AntemortemId"] = new SelectList(_context.Antemortems, "Id", "Id");

            return View("Index", viewModel);
        }
        // GET: ConductOfInspections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConductOfInspections == null)
            {
                return NotFound();
            }

            var conductOfInspection = await _context.ConductOfInspections.FindAsync(id);
            if (conductOfInspection == null)
            {
                return NotFound();
            }
            ViewData["AntemortemId"] = new SelectList(_context.Antemortems, "Id", "Id", conductOfInspection.AntemortemId);
            return View(conductOfInspection);
        }

        // POST: ConductOfInspections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Issue,NoOfHeads,Weight,Cause,AntemortemId")] ConductOfInspection conductOfInspection)
        {
            if (id != conductOfInspection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductOfInspection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductOfInspectionExists(conductOfInspection.Id))
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
            ViewData["AntemortemId"] = new SelectList(_context.Antemortems, "Id", "Id", conductOfInspection.AntemortemId);
            return View(conductOfInspection);
        }

        // GET: ConductOfInspections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConductOfInspections == null)
            {
                return NotFound();
            }

            var conductOfInspection = await _context.ConductOfInspections
                .Include(c => c.Antemortem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conductOfInspection == null)
            {
                return NotFound();
            }

            return View(conductOfInspection);
        }

        // POST: ConductOfInspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConductOfInspections == null)
            {
                return Problem("Entity set 'thesisContext.ConductOfInspections'  is null.");
            }
            var conductOfInspection = await _context.ConductOfInspections.FindAsync(id);
            if (conductOfInspection != null)
            {
                _context.ConductOfInspections.Remove(conductOfInspection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductOfInspectionExists(int id)
        {
            return (_context.ConductOfInspections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
