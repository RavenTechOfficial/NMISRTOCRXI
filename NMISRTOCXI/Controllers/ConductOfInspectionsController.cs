using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using DomainLayer.Models;

namespace thesis.Controllers
{
	public class ConductOfInspectionsController : Controller
	{
		private readonly AppDbContext _context;

		public ConductOfInspectionsController(AppDbContext context)
		{
			_context = context;
		}

		// GET: ConductOfInspections
		public async Task<IActionResult> Index(int myVariable)
		{
			ViewBag.AlertMessage = TempData["AlertMessage"] as string;
			ViewBag.AlertMessagee = TempData["AlertMessagee"] as string;
			ViewBag.MyVariable = myVariable;

			var viewModel = new ConductOfInspectionViewModel();

			// Filter the ConductOfInspections based on the provided MeatInspectionReportId
			viewModel.ConductOfInspections = await _context.Antemortems
				.Include(c => c.MeatInspectionReport)
				.Where(c => c.MeatInspectionReportId == myVariable)
				.ToListAsync();

			ViewData["MeatInspectionReportsId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id");

			return View("Index", viewModel.ConductOfInspections);
		}


		// GET: ConductOfInspections/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Antemortems == null)
			{
				return NotFound();
			}

			var conductOfInspection = await _context.Antemortems
				.Include(c => c.MeatInspectionReport)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (conductOfInspection == null)
			{
				return NotFound();
			}

			return View(conductOfInspection);
		}


		// GET: ConductOfInspections/Create
		public IActionResult Create(int meatInspectionReportId)
		{
			ViewData["meatInspectionReportId"] = meatInspectionReportId;


			var viewModel = new ConductOfInspectionViewModel();
			viewModel.ConductOfInspections = new List<MeatInspectionAntemortem>(); // Initialize the list
			viewModel.SingleConductOfInspection = new MeatInspectionAntemortem();

			//ViewData["MeatInspectionReportsId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id");
			int latestMeatInspectionReportsId = _context.MeatInspectionReports
				  .OrderByDescending(m => m.Id)
				 .Select(m => m.Id)
				 .FirstOrDefault();

			ViewData["MeatInspectionReportsId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id", latestMeatInspectionReportsId);
			ViewData["LatestMeatInspectionReportsId"] = latestMeatInspectionReportsId;

			viewModel.MeatInspectionReportId = latestMeatInspectionReportsId;

			return View(viewModel);
		}


		// POST: ConductOfInspections/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Issue,NoOfHeads,Weight,Cause,MeatInspectionReportId")] MeatInspectionAntemortem conductOfInspection)
		{
			if (ModelState.IsValid)
			{

				_context.Add(conductOfInspection);
				await _context.SaveChangesAsync();
				// return RedirectToAction(nameof(Index))
				TempData["AlertMessage"] = "Transaction Success";
				TempData["MeatInspectionReportId"] = conductOfInspection.MeatInspectionReportId;
				return RedirectToAction("Index", new { myVariable = conductOfInspection.MeatInspectionReportId });
				//return RedirectToAction("Create", "PassedForSlaughters");
			}

			// If there are validation errors, re-populate the ViewModel and return to the Create view.
			var viewModel = new ConductOfInspectionViewModel();
			viewModel.ConductOfInspections = await _context.Antemortems.Include(c => c.MeatInspectionReport).ToListAsync();
			viewModel.SingleConductOfInspection = new MeatInspectionAntemortem();
			viewModel.Issue = (Issue)conductOfInspection.Issue; // Initialize the Issue property

			ViewData["MeatInspectionReportId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id", conductOfInspection.MeatInspectionReportId);

			return View();
		}
		// GET: ConductOfInspections/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Antemortems == null)
			{
				return NotFound();
			}

			var conductOfInspection = await _context.Antemortems.FindAsync(id);
			if (conductOfInspection == null)
			{
				return NotFound();
			}
			ViewData["MeatInspectionReportsId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id", conductOfInspection.MeatInspectionReportId);
			return View(conductOfInspection);
		}

		// POST: ConductOfInspections/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Issue,NoOfHeads,Weight,Cause,MeatInspectionReportsId")] MeatInspectionAntemortem conductOfInspection)
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

			TempData["AlertMessage"] = "Transaction Success";
			ViewData["MeatInspectionReportsId"] = new SelectList(_context.MeatInspectionReports, "Id", "Id", conductOfInspection.MeatInspectionReportId);
			return View(conductOfInspection);
		}

		// GET: ConductOfInspections/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Antemortems == null)
			{
				return NotFound();
			}

			var conductOfInspection = await _context.Antemortems
				.Include(c => c.MeatInspectionReport)
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
			if (_context.Antemortems == null)
			{
				return Problem("Entity set 'AppDbContext.ConductOfInspections'  is null.");
			}
			var conductOfInspection = await _context.Antemortems.FindAsync(id);
			if (conductOfInspection != null)
			{
				_context.Antemortems.Remove(conductOfInspection);
			}

			await _context.SaveChangesAsync();
			TempData["AlertMessage"] = "Transaction Success";
			return RedirectToAction(nameof(Index));
		}

		private bool ConductOfInspectionExists(int id)
		{
			return (_context.Antemortems?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		// [HttpPost]
		//public IActionResult actionResult(int Id)
		//{
		//    // Use the Id value as needed
		//    var result = new ConductOfInspection
		//    {
		//        MeatInspectionReportsId = Id,
		//    };

		//    //_context.Add(result);
		//    //_context.SaveChanges();

		//    // Rest of your code...

		//    return View();
		//}
	}
}