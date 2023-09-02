
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Areas.Identity.Data;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
	public class ReceivingReportsController : Controller
	{


		private readonly thesisContext _context;
		private readonly UserManager<AccountDetails> _userManager;


		public ReceivingReportsController(thesisContext context, UserManager<AccountDetails> userManager)
		{
			_context = context;
			_userManager = userManager; ;
		}

		// GET: ReceivingReports
		public async Task<IActionResult> Index()
		{
			ViewBag.AlertMessage = TempData["AlertMessage"] as string;
			ViewBag.AlertMessagee = TempData["AlertMessagee"] as string;

			var thesisContext = _context.ReceivingReports
				.Include(r => r.AccountDetails)
				.Include(r => r.MeatDealers);
			return View(await thesisContext.ToListAsync());
		}



		// GET: ReceivingReports/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.ReceivingReports == null)
			{
				return NotFound();
			}

			var receivingReport = await _context.ReceivingReports
				.Include(r => r.AccountDetails)
				.Include(r => r.MeatDealers)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (receivingReport == null)
			{
				return NotFound();
			}

			return View(receivingReport);
		}

		// GET: ReceivingReports/Create
		public IActionResult Create()
		{
			var loggedInUserId = _userManager.GetUserId(User); // Replace this with your actual logic to get the logged-in user's ID.
			var loggedInUser = _context.Users.FirstOrDefault(user => user.Id == loggedInUserId);
			var meatDealersList = _context.MeatDealers.ToList();
			var concatenatedList = new List<SelectListItem>();

			foreach (var meatDealer in meatDealersList)
			{
				if (loggedInUser != null && meatDealer.MeatEstablishmentId == loggedInUser.MeatEstablishmentId)
				{
					var concatenatedValue = $"{meatDealer.FirstName} {meatDealer.LastName}";
					var selectListItem = new SelectListItem
					{
						Value = meatDealer.Id.ToString(),
						Text = concatenatedValue
					};
					concatenatedList.Add(selectListItem);
				}
			}

			ViewData["MeatDealersId"] = new SelectList(concatenatedList, "Value", "Text");

			var userList = _context.Users.ToList();
			var concatenatedList1 = new List<SelectListItem>();

			foreach (var user in userList)
			{
				var concatenatedValue = $"{user.firstName} {user.lastName}";
				var selectListItem = new SelectListItem
				{
					Value = user.Id.ToString(),
					Text = concatenatedValue
				};
				concatenatedList1.Add(selectListItem);
			}

			ViewData["AccountDetailsId"] = new SelectList(concatenatedList1, "Value", "Text");
			//    ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id");
			return View();
		}

		// POST: ReceivingReports/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,RecTime,BatchCode,Species,Category,NoOfHeads,LiveWeight,MeatDealersId,Origin,ShippingDoc,HoldingPenNo,ReceivingBy,AccountDetailsId,InspectionStatus")] ReceivingReport receivingReport)
		{
			if (ModelState.IsValid) //not not
			{
				_context.Add(receivingReport);
				await _context.SaveChangesAsync();
				TempData["AlertMessage"] = "Transaction Success";
				return RedirectToAction(nameof(Index));
			}
			ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id", receivingReport.AccountDetailsId);
			ViewData["MeatDealersId"] = new SelectList(_context.MeatDealers, "Id", "Id", receivingReport.MeatDealersId);
			return View(receivingReport);
		}

		// GET: ReceivingReports/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.ReceivingReports == null)
			{
				return NotFound();
			}

			var receivingReport = await _context.ReceivingReports.FindAsync(id);
			if (receivingReport == null)
			{
				return NotFound();
			}
			ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id", receivingReport.AccountDetailsId);
			//  ViewData["MeatDealersId"] = new SelectList(_context.MeatDealers, "Id", "Id", receivingReport.MeatDealersId);
			var meatDealersList = _context.MeatDealers.ToList();
			var concatenatedList = new List<SelectListItem>();

			foreach (var meatDealer in meatDealersList)
			{
				var concatenatedValue = $"{meatDealer.FirstName} {meatDealer.LastName}";
				var selectListItem = new SelectListItem
				{
					Value = meatDealer.Id.ToString(),
					Text = concatenatedValue
				};
				concatenatedList.Add(selectListItem);
			}
			ViewData["MeatDealersId"] = new SelectList(concatenatedList, "Value", "Text");
			return View(receivingReport);
		}

		// POST: ReceivingReports/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,RecTime,BatchCode,Species,Category,NoOfHeads,LiveWeight,MeatDealersId,Origin,ShippingDoc,HoldingPenNo,ReceivingBy,AccountDetailsId,InspectionStatus")] ReceivingReport receivingReport)
		{
			if (id != receivingReport.Id)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				try
				{
					_context.Update(receivingReport);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ReceivingReportExists(receivingReport.Id))
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
			ViewData["AccountDetailsId"] = new SelectList(_context.Users, "Id", "Id", receivingReport.AccountDetailsId);
			ViewData["MeatDealersId"] = new SelectList(_context.MeatDealers, "Id", "Id", receivingReport.MeatDealersId);
			return View(receivingReport);
		}

		// GET: ReceivingReports/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.ReceivingReports == null)
			{
				return NotFound();
			}

			var receivingReport = await _context.ReceivingReports
				.Include(r => r.AccountDetails)
				.Include(r => r.MeatDealers)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (receivingReport == null)
			{
				return NotFound();
			}

			return View(receivingReport);
		}

		// POST: ReceivingReports/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.ReceivingReports == null)
			{
				return Problem("Entity set 'thesisContext.ReceivingReports'  is null.");
			}
			var receivingReport = await _context.ReceivingReports.FindAsync(id);
			if (receivingReport != null)
			{
				_context.ReceivingReports.Remove(receivingReport);
			}

			await _context.SaveChangesAsync();
			TempData["AlertMessage"] = "Transaction Success";
			return RedirectToAction(nameof(Index));
		}

		private bool ReceivingReportExists(int id)
		{
			return (_context.ReceivingReports?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		[HttpPost]
		public IActionResult actionResult(int Id)
		{
			// Use the Id value as needed
			var result = new MeatInspectionReport
			{
				ReceivingReportId = Id,
				RepDate = DateTime.Now,
			};

			_context.Add(result);
			_context.SaveChanges();

			// Retrieve the MeatInspectionReportId after it is saved
			int meatInspectionReportId = result.Id;

			// Redirect to the Create action of ConductOfInspections controller and pass the MeatInspectionReportId
			return RedirectToAction("Create", "ConductOfInspections", new { meatInspectionReportId = meatInspectionReportId });

		}



	}
}

