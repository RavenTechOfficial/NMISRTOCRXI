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
			ViewData["ConductOfInspectionId"] = new SelectList(_context.ConductOfInspections, "Id", "Id");
			return View();
		}

		// POST: PassedForSlaughters/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,NoOfHeads,Weight,ConductOfInspectionId")] PassedForSlaughter passedForSlaughter)
		{
			if (!ModelState.IsValid)
			{
				_context.Add(passedForSlaughter);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
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
