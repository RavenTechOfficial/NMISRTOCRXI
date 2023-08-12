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
    public class PostmortemsController : Controller
    {
        private readonly thesisContext _context;

        public PostmortemsController(thesisContext context)
        {
            _context = context;
        }

        // GET: Postmortems
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.Postmortems.Include(p => p.PassedForSlaughter);
            return View(await thesisContext.ToListAsync());
        }

        // GET: Postmortems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postmortems == null)
            {
                return NotFound();
            }

            var postmortem = await _context.Postmortems
                .Include(p => p.PassedForSlaughter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postmortem == null)
            {
                return NotFound();
            }

            return View(postmortem);
        }

        // GET: Postmortems/Create
        public IActionResult Create()
        {
            var viewModel = new PostmortemViewModel
            {
                Postmortem = _context.Postmortems.Include(p => p.PassedForSlaughter).ToList(),
                // Populate any other necessary properties of the viewModel object
            };

            ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id");
            return View(viewModel);

        }

        // POST: Postmortems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PassedForSlaughterId,AnimalPart,Cause,Weight,NoOfHeads,Images")] Postmortem postmortem)
        {
            if (!
                ModelState.IsValid)
            {
                _context.Add(postmortem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);
            return View(postmortem);
        }

        // GET: Postmortems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Postmortems == null)
            {
                return NotFound();
            }

            var postmortem = await _context.Postmortems.FindAsync(id);
            if (postmortem == null)
            {
                return NotFound();
            }
            ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);
            return View(postmortem);
        }

        // POST: Postmortems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PassedForSlaughterId,AnimalPart,Cause,Weight,NoOfHeads,Images")] Postmortem postmortem)
        {
            if (id != postmortem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postmortem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostmortemExists(postmortem.Id))
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
            ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);
            return View(postmortem);
        }

        // GET: Postmortems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postmortems == null)
            {
                return NotFound();
            }

            var postmortem = await _context.Postmortems
                .Include(p => p.PassedForSlaughter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postmortem == null)
            {
                return NotFound();
            }

            return View(postmortem);
        }

        // POST: Postmortems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postmortems == null)
            {
                return Problem("Entity set 'thesisContext.Postmortems'  is null.");
            }
            var postmortem = await _context.Postmortems.FindAsync(id);
            if (postmortem != null)
            {
                _context.Postmortems.Remove(postmortem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostmortemExists(int id)
        {
            return (_context.Postmortems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
