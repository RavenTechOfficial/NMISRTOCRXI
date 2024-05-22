using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace NMISRTOCXI.Controllers
{
	[Authorize(Policy = "RequireInspectorAdmin")]
	public class ReceivingsController : Controller
    {
        private readonly AppDbContext _context;

        public ReceivingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Receivings
        public async Task<IActionResult> Index()
        {
            var AppDbContext = _context.Receivings.Include(r => r.AccountDetails);
            return View(await AppDbContext.ToListAsync());
        }

        // GET: Receivings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receivings == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receivings
                .Include(r => r.AccountDetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiving == null)
            {
                return NotFound();
            }

            return View(receiving);
        }

        // GET: Receivings/Create
        public IActionResult Create()
        {
            ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Receivings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecDate,AccountDetailsId")] Receiving receiving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id", receiving.AccountDetailsId);
            return View(receiving);
        }

        // GET: Receivings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receivings == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receivings.FindAsync(id);
            if (receiving == null)
            {
                return NotFound();
            }
            ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id", receiving.AccountDetailsId);
            return View(receiving);
        }

        // POST: Receivings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecDate,AccountDetailsId")] Receiving receiving)
        {
            if (id != receiving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceivingExists(receiving.Id))
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
            ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id", receiving.AccountDetailsId);
            return View(receiving);
        }

        // GET: Receivings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receivings == null)
            {
                return NotFound();
            }

            var receiving = await _context.Receivings
                .Include(r => r.AccountDetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiving == null)
            {
                return NotFound();
            }

            return View(receiving);
        }

        // POST: Receivings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receivings == null)
            {
                return Problem("Entity set 'AppDbContext.Receivings'  is null.");
            }
            var receiving = await _context.Receivings.FindAsync(id);
            if (receiving != null)
            {
                _context.Receivings.Remove(receiving);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceivingExists(int id)
        {
          return (_context.Receivings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
