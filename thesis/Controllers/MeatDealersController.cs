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
    public class MeatDealersController : Controller
    {
        private readonly thesisContext _context;

        public MeatDealersController(thesisContext context)
        {
            _context = context;
        }

        // GET: MeatDealers
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.MeatDealers.Include(m => m.MeatEstablishment);
            return View(await thesisContext.ToListAsync());
        }

        // GET: MeatDealers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeatDealers == null)
            {
                return NotFound();
            }

            var meatDealers = await _context.MeatDealers
                .Include(m => m.MeatEstablishment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meatDealers == null)
            {
                return NotFound();
            }

            return View(meatDealers);
        }

        // GET: MeatDealers/Create
        public IActionResult Create()
        {
            ViewData["MeatEstablishmentId"] = new SelectList(_context.MeatEstablishment, "Id", "Name");
            return View();
        }

        // POST: MeatDealers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Address,ContactNo,MeatEstablishmentId")] MeatDealers meatDealers)
        {
            if (!ModelState.IsValid) // not not
            {
                _context.Add(meatDealers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeatEstablishmentId"] = new SelectList(_context.MeatEstablishment, "Id", "Name", meatDealers.MeatEstablishmentId);
            return View(meatDealers);
        }

        // GET: MeatDealers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeatDealers == null)
            {
                return NotFound();
            }

            var meatDealers = await _context.MeatDealers.FindAsync(id);
            if (meatDealers == null)
            {
                return NotFound();
            }
            ViewData["MeatEstablishmentId"] = new SelectList(_context.MeatEstablishment, "Id", "Id", meatDealers.MeatEstablishmentId);
            return View(meatDealers);
        }

        // POST: MeatDealers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Address,ContactNo,MeatEstablishmentId")] MeatDealers meatDealers)
        {
            if (id != meatDealers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meatDealers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeatDealersExists(meatDealers.Id))
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
            ViewData["MeatEstablishmentId"] = new SelectList(_context.MeatEstablishment, "Id", "Id", meatDealers.MeatEstablishmentId);
            return View(meatDealers);
        }

        // GET: MeatDealers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeatDealers == null)
            {
                return NotFound();
            }

            var meatDealers = await _context.MeatDealers
                .Include(m => m.MeatEstablishment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meatDealers == null)
            {
                return NotFound();
            }

            return View(meatDealers);
        }

        // POST: MeatDealers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeatDealers == null)
            {
                return Problem("Entity set 'thesisContext.MeatDealers'  is null.");
            }
            var meatDealers = await _context.MeatDealers.FindAsync(id);
            if (meatDealers != null)
            {
                _context.MeatDealers.Remove(meatDealers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeatDealersExists(int id)
        {
            return (_context.MeatDealers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}
