using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class MTVapplicationController : Controller
    {
        private readonly thesisContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public MTVapplicationController(thesisContext context, IWebHostEnvironment webHostEnvironment)
		{
            _context = context;
			_webHostEnvironment = webHostEnvironment;

		}

        // GET: MTVapplication
        public async Task<IActionResult> Index()
        {
              return _context.MTVApplications != null ? 
                          View(await _context.MTVApplications.ToListAsync()) :
                          Problem("Entity set 'thesisContext.MTVApplications'  is null.");
        }

        // GET: MTVapplication/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MTVApplications == null)
            {
                return NotFound();
            }

            var mTVApplication = await _context.MTVApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mTVApplication == null)
            {
                return NotFound();
            }

            return View(mTVApplication);
        }

        // GET: MTVapplication/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MTVapplication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MtvApplicationViewModel mTVApplicationVM)
        {
			//mTVApplicationVM.Address = "Butuan City";
			//mTVApplicationVM.DriverAddress = "Davao City";
			//mTVApplicationVM.HelperAddress = "Cebu City";

			var imageLTOCR = "";
			if (mTVApplicationVM.LTOCR != null && mTVApplicationVM.LTOCR.Length > 0)
			{
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(mTVApplicationVM.LTOCR.FileName)}";
				var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/MTV", uniqueFileName);
				imageLTOCR = filePath;

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await mTVApplicationVM.LTOCR.CopyToAsync(fileStream);
				}
			}
			var imageLTOOR = "";
			if (mTVApplicationVM.LTOOR != null && mTVApplicationVM.LTOOR.Length > 0)
			{
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(mTVApplicationVM.LTOOR.FileName)}";
				var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/MTV", uniqueFileName);
				imageLTOOR = filePath;

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await mTVApplicationVM.LTOOR.CopyToAsync(fileStream);
				}
			}
			var imageLicenseFront = "";
			if (mTVApplicationVM.LicenseFront != null && mTVApplicationVM.LicenseFront.Length > 0)
			{
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(mTVApplicationVM.LicenseFront.FileName)}";
				var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/MTV", uniqueFileName);
				imageLicenseFront = filePath;

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await mTVApplicationVM.LicenseFront.CopyToAsync(fileStream);
				}
			}
			var imageLicenseBack = "";
			if (mTVApplicationVM.LicenseBack != null && mTVApplicationVM.LicenseBack.Length > 0)
			{
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(mTVApplicationVM.LicenseBack.FileName)}";
				var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/MTV", uniqueFileName);
				imageLicenseBack = filePath;

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await mTVApplicationVM.LicenseBack.CopyToAsync(fileStream);
				}
			}



			var mtv = new MTVApplication
			{
				applicationtype = mTVApplicationVM.applicationtype,
				OwnerFname = mTVApplicationVM.OwnerFname,
				OwnerMname = mTVApplicationVM.OwnerMname,
				OwnerLname = mTVApplicationVM.OwnerLname,
				Address = mTVApplicationVM.Address,
				Email = mTVApplicationVM.Email,
				TelNo = mTVApplicationVM.TelNo,
				FaxNo = mTVApplicationVM.FaxNo,
				Vehicle = new VehicleInfo
				{
					VehicleMaker = mTVApplicationVM.VehicleMaker,
					PlateNo = mTVApplicationVM.PlateNo,
					EngineNo = mTVApplicationVM.EngineNo,
					LTOCR = imageLTOCR,
					LTOOR = imageLTOOR,
					Est = mTVApplicationVM.Est,
					Destination = mTVApplicationVM.Destination,
				},
				Helper = new Helper
				{
					HelperFname = mTVApplicationVM.HelperFname,
					HelperMname = mTVApplicationVM.HelperMname,
					HelperLname = mTVApplicationVM.HelperLname,
					Address = mTVApplicationVM.HelperAddress,
					Email = mTVApplicationVM.HelperEmail,
					TelNo = mTVApplicationVM.HelperTelNo,
					birthdate = mTVApplicationVM.Helperbirthdate
				},
				Driver = new Driver
				{
					DriverFname = mTVApplicationVM.DriverFname,
					DriverMname = mTVApplicationVM.DriverMname,
					DriverLname = mTVApplicationVM.DriverLname,
					LicenseFront = imageLicenseFront,
					LicenseBack = imageLicenseBack,
					Address = mTVApplicationVM.DriverAddress,
					Email = mTVApplicationVM.DriverEmail,
					TelNo = mTVApplicationVM.DriverTelNo,
					gender = mTVApplicationVM.gender,
					birthdate = mTVApplicationVM.Driverbirthdate
				}

			};
                _context.Add(mtv);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "MTVquiz");
            
        }

        // GET: MTVapplication/Edit/5
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
            return View(mTVApplication);
        }

        // POST: MTVapplication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,applicationtype,OwnerFname,OwnerMname,OwnerLname,Address,Email,TelNo,FaxNo")] MTVApplication mTVApplication)
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
            return View(mTVApplication);
        }

        // GET: MTVapplication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MTVApplications == null)
            {
                return NotFound();
            }

            var mTVApplication = await _context.MTVApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mTVApplication == null)
            {
                return NotFound();
            }

            return View(mTVApplication);
        }

        // POST: MTVapplication/Delete/5
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
