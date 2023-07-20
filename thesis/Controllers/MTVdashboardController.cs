using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class MTVdashboardController : Controller
    {
        private readonly thesisContext _context;

        public MTVdashboardController(thesisContext context)
        {
            _context = context;
        }

		// GET: MTVdashboard
		[Authorize(Policy = "RequireMTVAdmin")]
		public async Task<IActionResult> Index()
        {
            var thesisContext = _context.MTVApplications.Include(m => m.Driver).Include(m => m.Helper).Include(m => m.Vehicle);
            return View(await thesisContext.ToListAsync());
        }

		// GET: MTVdashboard/Details/5
		[Authorize(Policy = "RequireMTVAdmin")]
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MTVApplications == null)
            {
                return NotFound();
            }

            var mTVApplication = await _context.MTVApplications
                .Include(m => m.Driver)
                .Include(m => m.Helper)
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mTVApplication == null)
            {
                return NotFound();
            }

            return View(mTVApplication);
        }

		// GET: MTVdashboard/Create
		[Authorize(Policy = "RequireMTVAdmin")]
		public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id");
            ViewData["HelperId"] = new SelectList(_context.Helpers, "Id", "Id");
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfos, "Id", "Id");
            return View();
        }

        // POST: MTVdashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OwnerFname,OwnerMname,OwnerLname,Address,Email,TelNo,FaxNo,VehicleId,HelperId,DriverId")] MTVApplication mTVApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mTVApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", mTVApplication.DriverId);
            ViewData["HelperId"] = new SelectList(_context.Helpers, "Id", "Id", mTVApplication.HelperId);
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfos, "Id", "Id", mTVApplication.VehicleId);
            return View(mTVApplication);
        }

		// GET: MTVdashboard/Edit/5
		[Authorize(Policy = "RequireMTVAdmin")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MTVApplications == null)
            {
                return NotFound();
            }

            var mTVApplication = await _context.MTVApplications.FindAsync(id);
            if (mTVApplication == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", mTVApplication.DriverId);
            ViewData["HelperId"] = new SelectList(_context.Helpers, "Id", "Id", mTVApplication.HelperId);
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfos, "Id", "Id", mTVApplication.VehicleId);
            return View(mTVApplication);
        }

        // POST: MTVdashboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OwnerFname,OwnerMname,OwnerLname,Address,Email,TelNo,FaxNo,VehicleId,HelperId,DriverId")] MTVApplication mTVApplication)
        {
            if (id != mTVApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mTVApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MTVApplicationExists(mTVApplication.Id))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", mTVApplication.DriverId);
            ViewData["HelperId"] = new SelectList(_context.Helpers, "Id", "Id", mTVApplication.HelperId);
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfos, "Id", "Id", mTVApplication.VehicleId);
            return View(mTVApplication);
        }

		// GET: MTVdashboard/Delete/5
		[Authorize(Policy = "RequireMTVAdmin")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MTVApplications == null)
            {
                return NotFound();
            }

            var mTVApplication = await _context.MTVApplications
                .Include(m => m.Driver)
                .Include(m => m.Helper)
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mTVApplication == null)
            {
                return NotFound();
            }

            return View(mTVApplication);
        }

        // POST: MTVdashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MTVApplications == null)
            {
                return Problem("Entity set 'thesisContext.MTVApplications'  is null.");
            }
            var mTVApplication = await _context.MTVApplications.FindAsync(id);
            if (mTVApplication != null)
            {
                _context.MTVApplications.Remove(mTVApplication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MTVApplicationExists(int id)
        {
          return (_context.MTVApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
