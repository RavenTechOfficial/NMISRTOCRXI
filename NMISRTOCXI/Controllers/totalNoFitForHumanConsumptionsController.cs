using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace thesis.Controllers
{
	public class TotalNoFitForHumanConsumptionsController : Controller
	{
		private readonly AppDbContext _context;

		public TotalNoFitForHumanConsumptionsController(AppDbContext context)
		{
			_context = context;
		}

		// GET: TotalNoFitForHumanConsumptions
		public async Task<IActionResult> Index()
		{
			var AppDbContext = _context.TotalNoFitForHumanConsumptions.Include(t => t.Postmortem);
			return View(await AppDbContext.ToListAsync());
		}

		// GET: TotalNoFitForHumanConsumptions/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.TotalNoFitForHumanConsumptions == null)
			{
				return NotFound();
			}

			var TotalNoFitForHumanConsumptions = await _context.TotalNoFitForHumanConsumptions
				.Include(t => t.Postmortem)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (TotalNoFitForHumanConsumptions == null)
			{
				return NotFound();
			}

			return View(TotalNoFitForHumanConsumptions);
		}

		// GET: TotalNoFitForHumanConsumptions/Create
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

		// POST: TotalNoFitForHumanConsumptions/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Species,NoOfHeads,DressedWeight,PostmortemId")] TotalNoFitForHumanConsumptions TotalNoFitForHumanConsumptions)
		{
			if (ModelState.IsValid)
			{
				_context.Add(TotalNoFitForHumanConsumptions);
				await _context.SaveChangesAsync();
				//   return RedirectToAction(nameof(Index));
				return RedirectToAction("Create", "SummaryAndDistributionOfMICs");
			}
			ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id", TotalNoFitForHumanConsumptions.PostmortemId);
			return View();
		}

		// GET: TotalNoFitForHumanConsumptions/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.TotalNoFitForHumanConsumptions == null)
			{
				return NotFound();
			}

			var TotalNoFitForHumanConsumptions = await _context.TotalNoFitForHumanConsumptions.FindAsync(id);
			if (TotalNoFitForHumanConsumptions == null)
			{
				return NotFound();
			}
			ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id", TotalNoFitForHumanConsumptions.PostmortemId);
			return View(TotalNoFitForHumanConsumptions);
		}

		// POST: TotalNoFitForHumanConsumptions/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Species,NoOfHeads,DressedWeight,PostmortemId")] TotalNoFitForHumanConsumptions TotalNoFitForHumanConsumptions)
		{
			if (id != TotalNoFitForHumanConsumptions.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(TotalNoFitForHumanConsumptions);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TotalNoFitForHumanConsumptionsExists(TotalNoFitForHumanConsumptions.Id))
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
			ViewData["PostmortemId"] = new SelectList(_context.Postmortems, "Id", "Id", TotalNoFitForHumanConsumptions.PostmortemId);
			return View(TotalNoFitForHumanConsumptions);
		}

		// GET: TotalNoFitForHumanConsumptions/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.TotalNoFitForHumanConsumptions == null)
			{
				return NotFound();
			}

			var TotalNoFitForHumanConsumptions = await _context.TotalNoFitForHumanConsumptions
				.Include(t => t.Postmortem)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (TotalNoFitForHumanConsumptions == null)
			{
				return NotFound();
			}

			return View(TotalNoFitForHumanConsumptions);
		}

		// POST: TotalNoFitForHumanConsumptions/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.TotalNoFitForHumanConsumptions == null)
			{
				return Problem("Entity set 'AppDbContext.TotalNoFitForHumanConsumptions'  is null.");
			}
			var TotalNoFitForHumanConsumptions = await _context.TotalNoFitForHumanConsumptions.FindAsync(id);
			if (TotalNoFitForHumanConsumptions != null)
			{
				_context.TotalNoFitForHumanConsumptions.Remove(TotalNoFitForHumanConsumptions);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TotalNoFitForHumanConsumptionsExists(int id)
		{
			return (_context.TotalNoFitForHumanConsumptions?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
