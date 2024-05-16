using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfastructureLayer.Data;


namespace thesis.Controllers
{
    //[Authorize(Policy = "RequireInspectorAdmin")]
    public class MeatDealersController : Controller
	{
		private readonly AppDbContext _context;
		private readonly UserManager<AccountDetails> _userManager; // Add the type argument 'AccountDetails'
		public MeatDealersController(AppDbContext context, UserManager<AccountDetails> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: MeatDealers
		public async Task<IActionResult> Index()
		{
			ViewBag.AlertMessage = TempData["AlertMessage"] as string;
			ViewBag.AlertMessagee = TempData["AlertMessagee"] as string;
			var AppDbContext = _context.MeatDealers.Include(m => m.MeatEstablishment);
			return View(await AppDbContext.ToListAsync());
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
			var currentUser = _userManager.GetUserAsync(User).Result;

			if (currentUser == null || currentUser.MeatEstablishmentId == null)
			{
				return BadRequest("User is not associated with any MeatEstablishment.");
			}

			var meatEstablishmentsQuery = from meatEstablishment in _context.MeatEstablishments
										  where meatEstablishment.Id == currentUser.MeatEstablishmentId
										  select new
										  {
											  meatEstablishment.Id,
											  meatEstablishment.Name
										  };

			ViewData["MeatEstablishmentId"] = new SelectList(meatEstablishmentsQuery, "Id", "Name");
			return View();
		}


		// POST: MeatDealers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Address,ContactNo,MeatEstablishmentId")] MeatDealer meatDealers)
		{

			if (!ModelState.IsValid) // not not
			{
				_context.Add(meatDealers);
				await _context.SaveChangesAsync();
				TempData["AlertMessage"] = "Transaction Success";

				return RedirectToAction(nameof(Index));
			}
			ViewData["MeatEstablishmentId"] = new SelectList(_context.MeatEstablishments, "Id", "Name", meatDealers.MeatEstablishmentId);
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
			ViewData["MeatEstablishmentId"] = new SelectList(_context.MeatEstablishments, "Id", "Id", meatDealers.MeatEstablishmentId);
			return View(meatDealers);
		}

		// POST: MeatDealers/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Address,ContactNo,MeatEstablishmentId")] MeatDealer meatDealers)
		{
			if (id != meatDealers.Id)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
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
				TempData["AlertMessagee"] = "Transaction Success";

				return RedirectToAction(nameof(Index));
			}
			ViewData["MeatEstablishmentId"] = new SelectList(_context.MeatEstablishments, "Id", "Id", meatDealers.MeatEstablishmentId);
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
				return Problem("Entity set 'AppDbContext.MeatDealers'  is null.");
			}
			var meatDealers = await _context.MeatDealers.FindAsync(id);
			if (meatDealers != null)
			{
				_context.MeatDealers.Remove(meatDealers);
				TempData["AlertMessage"] = "Transaction Success";

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