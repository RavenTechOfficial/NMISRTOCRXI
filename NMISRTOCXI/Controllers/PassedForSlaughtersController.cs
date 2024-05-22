using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfastructureLayer.Data;
using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;

namespace NMISRTOCXI.Controllers
{
	public class PassedForSlaughtersController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public PassedForSlaughtersController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


        [HttpPost]
        public async Task<IActionResult> Create(int passedHead, double passedWeight, Guid Id)
        {
            var passedForSlaughter = await _unitOfWork.PassedForSlaughter.Get(c => c.ReceivingReportId == Id);

            if (passedForSlaughter == null)
            {
                passedForSlaughter = new PassedForSlaughter
                {
                    ReceivingReportId = Id,
                    NoOfHeads = passedHead,
                    Weight = passedWeight,
                };

                _unitOfWork.PassedForSlaughter.Add(passedForSlaughter);
            }
            else
            {
                passedForSlaughter.NoOfHeads = passedHead;
                passedForSlaughter.Weight = passedWeight;

                _unitOfWork.PassedForSlaughter.Update(passedForSlaughter);
            }

            await _unitOfWork.Save();

            var response = new
            {
                success = true,
            };

            return Json(response);
        }

        //		// GET: PassedForSlaughters
        //		public async Task<IActionResult> Index()
        //		{
        //			var IUnitOfWork = _unitOfWork.PassedForSlaughters.Include(p => p.ConductOfInspection);
        //			return View(await IUnitOfWork.ToListAsync());
        //		}

        //		// GET: PassedForSlaughters/Details/5
        //		public async Task<IActionResult> Details(int? id)
        //		{
        //			if (id == null || _unitOfWork.PassedForSlaughters == null)
        //			{
        //				return NotFound();
        //			}

        //			var passedForSlaughter = await _unitOfWork.PassedForSlaughters
        //				.Include(p => p.ConductOfInspection)
        //				.FirstOrDefaultAsync(m => m.Id == id);
        //			if (passedForSlaughter == null)
        //			{
        //				return NotFound();
        //			}

        //			return View(passedForSlaughter);
        //		}

        //		// GET: PassedForSlaughters/Create
        //		public IActionResult Create()
        //		{
        //			//int? meatInspectionReportId = TempData["MeatInspectionReportId"] as int?;

        //			//int mostRecentId = (int)meatInspectionReportId;

        //			//// Execute the first SQL query and retrieve the results
        //			//var firstQueryResult = _unitOfWork.ConductOfInspections
        //			//	.Where(ci => ci.MeatInspectionReportId == mostRecentId)
        //			//	.GroupBy(ci => ci.MeatInspectionReportId)
        //			//	.Select(g => new
        //			//	{
        //			//		MeatInspectionReportId = g.Key,
        //			//		TotalNoOfHeads = g.Sum(ci => ci.NoOfHeads),
        //			//		TotalWeight = g.Sum(ci => ci.Weight)
        //			//	})
        //			//	.FirstOrDefault();

        //			//// Execute the second SQL query and retrieve the results
        //			//var secondQueryResult = _unitOfWork.MeatInspectionReports
        //			//	.Where(mir => mir.Id == mostRecentId)
        //			//	.Join(_unitOfWork.ReceivingReports, mir => mir.ReceivingReportId, rr => rr.Id, (mir, rr) => new
        //			//	{
        //			//		ReceivingNoOfHeads = rr.NoOfHeads,
        //			//		InspectionNoOfHeads = _unitOfWork.ConductOfInspections
        //			//			.Where(ci => ci.MeatInspectionReportId == mostRecentId)
        //			//			.Sum(ci => ci.NoOfHeads),
        //			//		TotalNoOfHeads = firstQueryResult.TotalNoOfHeads
        //			//	})
        //			//	.Select(result => new
        //			//	{
        //			//		result.ReceivingNoOfHeads,
        //			//		result.InspectionNoOfHeads,
        //			//		PassedForSlaughterHeads = result.ReceivingNoOfHeads - result.TotalNoOfHeads
        //			//	})
        //			//	.FirstOrDefault();

        //			//// Execute the third SQL query and retrieve the results
        //			//var thirdQueryResult = _unitOfWork.MeatInspectionReports
        //			//	.Where(mir => mir.Id == mostRecentId)
        //			//	.Join(_unitOfWork.ReceivingReports, mir => mir.ReceivingReportId, rr => rr.Id, (mir, rr) => new
        //			//	{
        //			//		ReceivingLiveWeight = rr.LiveWeight,
        //			//		InspectionWeight = _unitOfWork.ConductOfInspections
        //			//			.Where(ci => ci.MeatInspectionReportId == mostRecentId)
        //			//			.Sum(ci => ci.Weight),
        //			//		TotalWeight = firstQueryResult.TotalWeight
        //			//	})
        //			//	.Select(result => new
        //			//	{
        //			//		result.ReceivingLiveWeight,
        //			//		result.InspectionWeight,
        //			//		PassedForSlaughterWeight = result.ReceivingLiveWeight - result.TotalWeight
        //			//	})
        //			//	.FirstOrDefault();

        //			//// You can now use the 'secondQueryResult' and 'thirdQueryResult' to pass data to the view
        //			//ViewData["ReceivingNoOfHeads"] = secondQueryResult?.ReceivingNoOfHeads;
        //			//ViewData["InspectionNoOfHeads"] = secondQueryResult?.InspectionNoOfHeads;
        //			//ViewData["PassedForSlaughterHeads"] = secondQueryResult?.PassedForSlaughterHeads;
        //			//ViewData["ReceivingLiveWeight"] = thirdQueryResult?.ReceivingLiveWeight;
        //			//ViewData["InspectionWeight"] = thirdQueryResult?.InspectionWeight;
        //			//ViewData["PassedForSlaughterWeight"] = thirdQueryResult?.PassedForSlaughterWeight;

        //			//int mostRecentId1 = _unitOfWork.ConductOfInspections
        //			//		.OrderByDescending(c => c.Id)
        //			//		.Select(c => c.Id)
        //			//		.FirstOrDefault();
        //			//ViewData["ConductOfInspectionId"] = new SelectList(_unitOfWork.ConductOfInspections, "Id", "Id", mostRecentId1);
        //			return View();
        //		}
        //		//public IActionResult Create()
        //		//{
        //		//    int? meatInspectionReportId = TempData["MeatInspectionReportId"] as int?;

        //		//    //int mostRecentId = _unitOfWork.ConductOfInspections
        //		//    //    .OrderByDescending(c => c.Id)
        //		//    //    .Select(c => c.Id)
        //		//    //    .FirstOrDefault();
        //		//    int mostRecentId = (int)meatInspectionReportId;

        //		//    var receivingReportIds = _unitOfWork.MeatInspectionReports
        //		//        .Join(
        //		//            _unitOfWork.ConductOfInspections,
        //		//            mir => mir.Id,
        //		//            coi => coi.MeatInspectionReportId,
        //		//            (mir, coi) => new { MeatInspectionReport = mir, ConductOfInspection = coi }
        //		//        )
        //		//        .Where(joinResult => joinResult.ConductOfInspection.Id == mostRecentId)
        //		//        .Select(joinResult => joinResult.MeatInspectionReport.ReceivingReportId)
        //		//        .ToList();

        //		//    // Retrieve the calculated differences for NoOfHeads and Weight using your queries
        //		//    var differencesNoOfHeads = _unitOfWork.ReceivingReports
        //		//        .Join(
        //		//            _unitOfWork.MeatInspectionReports,
        //		//            rr => rr.Id,
        //		//            mir => mir.ReceivingReportId,
        //		//            (rr, mir) => new { ReceivingNoOfHeads = rr.NoOfHeads, MeatInspectionReportsId = mir.Id }
        //		//        )
        //		//        .Join(
        //		//            _unitOfWork.ConductOfInspections,
        //		//            rrmir => rrmir.MeatInspectionReportsId,
        //		//            ci => ci.MeatInspectionReportId,
        //		//            (rrmir, ci) => new { rrmir.ReceivingNoOfHeads, InspectionNoOfHeads = ci.NoOfHeads, PassedForSlaughter = rrmir.ReceivingNoOfHeads - ci.NoOfHeads }
        //		//        )
        //		//        .ToList();

        //		//    var differencesWeight = _unitOfWork.ReceivingReports
        //		//        .Join(
        //		//            _unitOfWork.MeatInspectionReports,
        //		//            rr => rr.Id,
        //		//            mir => mir.ReceivingReportId,
        //		//            (rr, mir) => new { LiveWeight = rr.LiveWeight, MeatInspectionReportsId = mir.Id }
        //		//        )
        //		//        .Join(
        //		//            _unitOfWork.ConductOfInspections,
        //		//            rrmir => rrmir.MeatInspectionReportsId,
        //		//            ci => ci.MeatInspectionReportId,
        //		//            (rrmir, ci) => new { rrmir.LiveWeight, InspectionWeight = ci.Weight, PassedForSlaughterWeight = rrmir.LiveWeight - ci.Weight }
        //		//        )
        //		//        .ToList();

        //		//    int calculatedDifferenceNoOfHeads = differencesNoOfHeads.Select(result => result.PassedForSlaughter).Last();
        //		//    decimal calculatedDifferenceWeight = differencesWeight.Select(result => result.PassedForSlaughterWeight).Last();

        //		//    // Set the default values for the fields
        //		//    ViewData["ConductOfInspectionId"] = new SelectList(_unitOfWork.ConductOfInspections, "Id", "Id", mostRecentId);
        //		//    ViewData["CalculatedDifferenceNoOfHeads"] = calculatedDifferenceNoOfHeads;
        //		//    ViewData["CalculatedDifferenceWeight"] = calculatedDifferenceWeight;

        //		//    return View();
        //		//}


        //		// POST: PassedForSlaughters/Create
        //		// To protect from overposting attacks, enable the specific properties you want to bind to.
        //		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //		[HttpPost]
        //		[ValidateAntiForgeryToken]
        //		public async Task<IActionResult> Create([Bind("Id,NoOfHeads,Weight,ConductOfInspectionId")] PassedForSlaughter passedForSlaughter)
        //		{
        //			if (ModelState.IsValid)
        //			{
        //				_unitOfWork.Add(passedForSlaughter);
        //				await _unitOfWork.SaveChangesAsync();
        //				//   return RedirectToAction(nameof(Index));
        //				return RedirectToAction("Create", "Postmortems");
        //			}
        //			ViewData["ConductOfInspectionId"] = new SelectList(_unitOfWork.Antemortems, "Id", "Id", passedForSlaughter.ConductOfInspectionId);
        //			return View(passedForSlaughter);
        //		}

        //		// GET: PassedForSlaughters/Edit/5
        //		public async Task<IActionResult> Edit(int? id)
        //		{
        //			if (id == null || _unitOfWork.PassedForSlaughters == null)
        //			{
        //				return NotFound();
        //			}

        //			var passedForSlaughter = await _unitOfWork.PassedForSlaughters.FindAsync(id);
        //			if (passedForSlaughter == null)
        //			{
        //				return NotFound();
        //			}
        //			ViewData["ConductOfInspectionId"] = new SelectList(_unitOfWork.Antemortems, "Id", "Id", passedForSlaughter.ConductOfInspectionId);
        //			return View(passedForSlaughter);
        //		}

        //		// POST: PassedForSlaughters/Edit/5
        //		// To protect from overposting attacks, enable the specific properties you want to bind to.
        //		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //		[HttpPost]
        //		[ValidateAntiForgeryToken]
        //		public async Task<IActionResult> Edit(int id, [Bind("Id,NoOfHeads,Weight,ConductOfInspectionId")] PassedForSlaughter passedForSlaughter)
        //		{
        //			if (id != passedForSlaughter.Id)
        //			{
        //				return NotFound();
        //			}

        //			if (ModelState.IsValid)
        //			{
        //				try
        //				{
        //					_unitOfWork.Update(passedForSlaughter);
        //					await _unitOfWork.SaveChangesAsync();
        //				}
        //				catch (DbUpdateConcurrencyException)
        //				{
        //					if (!PassedForSlaughterExists(passedForSlaughter.Id))
        //					{
        //						return NotFound();
        //					}
        //					else
        //					{
        //						throw;
        //					}
        //				}
        //				return RedirectToAction(nameof(Index));
        //			}
        //			ViewData["ConductOfInspectionId"] = new SelectList(_unitOfWork.Antemortems, "Id", "Id", passedForSlaughter.ConductOfInspectionId);
        //			return View(passedForSlaughter);
        //		}

        //		// GET: PassedForSlaughters/Delete/5
        //		public async Task<IActionResult> Delete(int? id)
        //		{
        //			if (id == null || _unitOfWork.PassedForSlaughters == null)
        //			{
        //				return NotFound();
        //			}

        //			var passedForSlaughter = await _unitOfWork.PassedForSlaughters
        //				.Include(p => p.ConductOfInspection)
        //				.FirstOrDefaultAsync(m => m.Id == id);
        //			if (passedForSlaughter == null)
        //			{
        //				return NotFound();
        //			}

        //			return View(passedForSlaughter);
        //		}

        //		// POST: PassedForSlaughters/Delete/5
        //		[HttpPost, ActionName("Delete")]
        //		[ValidateAntiForgeryToken]
        //		public async Task<IActionResult> DeleteConfirmed(int id)
        //		{
        //			if (_unitOfWork.PassedForSlaughters == null)
        //			{
        //				return Problem("Entity set 'IUnitOfWork.PassedForSlaughters'  is null.");
        //			}
        //			var passedForSlaughter = await _unitOfWork.PassedForSlaughters.FindAsync(id);
        //			if (passedForSlaughter != null)
        //			{
        //				_unitOfWork.PassedForSlaughters.Remove(passedForSlaughter);
        //			}

        //			await _unitOfWork.SaveChangesAsync();
        //			return RedirectToAction(nameof(Index));
        //		}

        //		private bool PassedForSlaughterExists(int id)
        //		{
        //			return (_unitOfWork.PassedForSlaughters?.Any(e => e.Id == id)).GetValueOrDefault();
        //		}
    }
}
