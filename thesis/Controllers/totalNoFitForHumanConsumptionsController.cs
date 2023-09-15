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
			int? passedForSlaughterId = TempData["PassedForSlaughterId"] as int?;
			int mostRecentId = (int)passedForSlaughterId;

			// Check if the specific PassedForSlaughterId has multiple inputs
			var multipleInputs = _context.Postmortems
				.Where(pm => pm.PassedForSlaughterId == mostRecentId)
				.GroupBy(pm => pm.PassedForSlaughterId)
				.Select(group => new { PassedForSlaughterId = group.Key, TotalPostWeight = group.Sum(pm => pm.Weight), TotalPostNoOfHeads = group.Sum(pm => pm.NoOfHeads) })
				.FirstOrDefault();

			if (multipleInputs == null)
			{
				// Handle the case when there are no multiple inputs
				// You might want to show an error message or take other actions
			}
			else
			{
				double totalPostWeight = multipleInputs.TotalPostWeight; //double or float
				int totalPostNoOfHeads = multipleInputs.TotalPostNoOfHeads;

				// Execute the provided SQL queries using LINQ to calculate the differences
				var passedForSlaughterData = _context.PassedForSlaughters
					.Where(pfs => pfs.Id == mostRecentId)
					.Select(pfs => new
					{
						InspectionWeight = pfs.Weight,
						InspectionNoOfHeads = pfs.NoOfHeads,
						PostWeight = totalPostWeight,
						PostNoOfHeads = totalPostNoOfHeads,
						WeightPassed = pfs.Weight - totalPostWeight,
						NoOfHeadsPassed = pfs.NoOfHeads - totalPostNoOfHeads
					})
					.FirstOrDefault();

				if (passedForSlaughterData == null)
				{
					// Handle the case when data is not found
					// You might want to show an error message or take other actions
				}
				else
				{
					// Pass the calculated data to the view
					ViewData["WeightPassed"] = passedForSlaughterData.WeightPassed;
					ViewData["NoOfHeadsPassed"] = passedForSlaughterData.NoOfHeadsPassed;

				}
			}
			//ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id");
			//return View();
			int latestId = _context.Postmortems.OrderByDescending(p => p.Id).FirstOrDefault()?.Id ?? 0;
			ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id", latestId);
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
