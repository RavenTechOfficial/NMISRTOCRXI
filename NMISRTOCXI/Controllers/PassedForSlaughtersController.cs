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
	public class PassedForSlaughtersController : Controller
	{
		private readonly AppDbContext _context;

		public PassedForSlaughtersController(AppDbContext context)
		{
			_context = context;
		}

		// GET: PassedForSlaughters
		public async Task<IActionResult> Index()
		{
			var AppDbContext = _context.PassedForSlaughters.Include(p => p.ConductOfInspection);
			return View(await AppDbContext.ToListAsync());
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
			//int? meatInspectionReportId = TempData["MeatInspectionReportId"] as int?;

			//int mostRecentId = (int)meatInspectionReportId;

			//// Execute the first SQL query and retrieve the results
			//var firstQueryResult = _context.ConductOfInspections
			//	.Where(ci => ci.MeatInspectionReportId == mostRecentId)
			//	.GroupBy(ci => ci.MeatInspectionReportId)
			//	.Select(g => new
			//	{
			//		MeatInspectionReportId = g.Key,
			//		TotalNoOfHeads = g.Sum(ci => ci.NoOfHeads),
			//		TotalWeight = g.Sum(ci => ci.Weight)
			//	})
			//	.FirstOrDefault();

			//// Execute the second SQL query and retrieve the results
			//var secondQueryResult = _context.MeatInspectionReports
			//	.Where(mir => mir.Id == mostRecentId)
			//	.Join(_context.ReceivingReports, mir => mir.ReceivingReportId, rr => rr.Id, (mir, rr) => new
			//	{
			//		ReceivingNoOfHeads = rr.NoOfHeads,
			//		InspectionNoOfHeads = _context.ConductOfInspections
			//			.Where(ci => ci.MeatInspectionReportId == mostRecentId)
			//			.Sum(ci => ci.NoOfHeads),
			//		TotalNoOfHeads = firstQueryResult.TotalNoOfHeads
			//	})
			//	.Select(result => new
			//	{
			//		result.ReceivingNoOfHeads,
			//		result.InspectionNoOfHeads,
			//		PassedForSlaughterHeads = result.ReceivingNoOfHeads - result.TotalNoOfHeads
			//	})
			//	.FirstOrDefault();

			//// Execute the third SQL query and retrieve the results
			//var thirdQueryResult = _context.MeatInspectionReports
			//	.Where(mir => mir.Id == mostRecentId)
			//	.Join(_context.ReceivingReports, mir => mir.ReceivingReportId, rr => rr.Id, (mir, rr) => new
			//	{
			//		ReceivingLiveWeight = rr.LiveWeight,
			//		InspectionWeight = _context.ConductOfInspections
			//			.Where(ci => ci.MeatInspectionReportId == mostRecentId)
			//			.Sum(ci => ci.Weight),
			//		TotalWeight = firstQueryResult.TotalWeight
			//	})
			//	.Select(result => new
			//	{
			//		result.ReceivingLiveWeight,
			//		result.InspectionWeight,
			//		PassedForSlaughterWeight = result.ReceivingLiveWeight - result.TotalWeight
			//	})
			//	.FirstOrDefault();

			//// You can now use the 'secondQueryResult' and 'thirdQueryResult' to pass data to the view
			//ViewData["ReceivingNoOfHeads"] = secondQueryResult?.ReceivingNoOfHeads;
			//ViewData["InspectionNoOfHeads"] = secondQueryResult?.InspectionNoOfHeads;
			//ViewData["PassedForSlaughterHeads"] = secondQueryResult?.PassedForSlaughterHeads;
			//ViewData["ReceivingLiveWeight"] = thirdQueryResult?.ReceivingLiveWeight;
			//ViewData["InspectionWeight"] = thirdQueryResult?.InspectionWeight;
			//ViewData["PassedForSlaughterWeight"] = thirdQueryResult?.PassedForSlaughterWeight;

			//int mostRecentId1 = _context.ConductOfInspections
			//		.OrderByDescending(c => c.Id)
			//		.Select(c => c.Id)
			//		.FirstOrDefault();
			//ViewData["ConductOfInspectionId"] = new SelectList(_context.ConductOfInspections, "Id", "Id", mostRecentId1);
			return View();
		}
		//public IActionResult Create()
		//{
		//    int? meatInspectionReportId = TempData["MeatInspectionReportId"] as int?;

		//    //int mostRecentId = _context.ConductOfInspections
		//    //    .OrderByDescending(c => c.Id)
		//    //    .Select(c => c.Id)
		//    //    .FirstOrDefault();
		//    int mostRecentId = (int)meatInspectionReportId;

		//    var receivingReportIds = _context.MeatInspectionReports
		//        .Join(
		//            _context.ConductOfInspections,
		//            mir => mir.Id,
		//            coi => coi.MeatInspectionReportId,
		//            (mir, coi) => new { MeatInspectionReport = mir, ConductOfInspection = coi }
		//        )
		//        .Where(joinResult => joinResult.ConductOfInspection.Id == mostRecentId)
		//        .Select(joinResult => joinResult.MeatInspectionReport.ReceivingReportId)
		//        .ToList();

		//    // Retrieve the calculated differences for NoOfHeads and Weight using your queries
		//    var differencesNoOfHeads = _context.ReceivingReports
		//        .Join(
		//            _context.MeatInspectionReports,
		//            rr => rr.Id,
		//            mir => mir.ReceivingReportId,
		//            (rr, mir) => new { ReceivingNoOfHeads = rr.NoOfHeads, MeatInspectionReportsId = mir.Id }
		//        )
		//        .Join(
		//            _context.ConductOfInspections,
		//            rrmir => rrmir.MeatInspectionReportsId,
		//            ci => ci.MeatInspectionReportId,
		//            (rrmir, ci) => new { rrmir.ReceivingNoOfHeads, InspectionNoOfHeads = ci.NoOfHeads, PassedForSlaughter = rrmir.ReceivingNoOfHeads - ci.NoOfHeads }
		//        )
		//        .ToList();

		//    var differencesWeight = _context.ReceivingReports
		//        .Join(
		//            _context.MeatInspectionReports,
		//            rr => rr.Id,
		//            mir => mir.ReceivingReportId,
		//            (rr, mir) => new { LiveWeight = rr.LiveWeight, MeatInspectionReportsId = mir.Id }
		//        )
		//        .Join(
		//            _context.ConductOfInspections,
		//            rrmir => rrmir.MeatInspectionReportsId,
		//            ci => ci.MeatInspectionReportId,
		//            (rrmir, ci) => new { rrmir.LiveWeight, InspectionWeight = ci.Weight, PassedForSlaughterWeight = rrmir.LiveWeight - ci.Weight }
		//        )
		//        .ToList();

		//    int calculatedDifferenceNoOfHeads = differencesNoOfHeads.Select(result => result.PassedForSlaughter).Last();
		//    decimal calculatedDifferenceWeight = differencesWeight.Select(result => result.PassedForSlaughterWeight).Last();

		//    // Set the default values for the fields
		//    ViewData["ConductOfInspectionId"] = new SelectList(_context.ConductOfInspections, "Id", "Id", mostRecentId);
		//    ViewData["CalculatedDifferenceNoOfHeads"] = calculatedDifferenceNoOfHeads;
		//    ViewData["CalculatedDifferenceWeight"] = calculatedDifferenceWeight;

		//    return View();
		//}


		// POST: PassedForSlaughters/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,NoOfHeads,Weight,ConductOfInspectionId")] PassedForSlaughter passedForSlaughter)
		{
			if (ModelState.IsValid)
			{
				_context.Add(passedForSlaughter);
				await _context.SaveChangesAsync();
				//   return RedirectToAction(nameof(Index));
				return RedirectToAction("Create", "Postmortems");
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
				return Problem("Entity set 'AppDbContext.PassedForSlaughters'  is null.");
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
