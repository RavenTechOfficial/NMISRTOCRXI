using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace thesis.Controllers
{
    public class MTVapplicationController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public MTVapplicationController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
		{
            _context = context;
			_webHostEnvironment = webHostEnvironment;

		}

		// GET: MTVapplication
		[Authorize(Policy = "RequireMtvUsers")]
		public async Task<IActionResult> Index()
        {
              return _context.MTVApplications != null ? 
                          View(await _context.MTVApplications.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.MTVApplications'  is null.");
        }

		// GET: MTVapplication/Details/5
		[Authorize(Policy = "RequireMtvUsers")]
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
		[Authorize(Policy = "RequireMtvUsers")]
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
				AccreditationNo = mTVApplicationVM.AccreditionNo,
				OwnerFirstName = mTVApplicationVM.OwnerFname,
				OwnerMiddleName = mTVApplicationVM.OwnerMname,
				OwnerLastName = mTVApplicationVM.OwnerLname,
				Address = mTVApplicationVM.Address,
				Email = mTVApplicationVM.Email,
				ContactNo = mTVApplicationVM.TelNo,
				FaxNo = mTVApplicationVM.FaxNo,
                Status = mTVApplicationVM.Status,
				VehicleInfo = new VehicleInfo
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
					FirstName = mTVApplicationVM.HelperFname,
					MiddleName = mTVApplicationVM.HelperMname,
					LastName = mTVApplicationVM.HelperLname,
					Address = mTVApplicationVM.HelperAddress,
					Email = mTVApplicationVM.HelperEmail,
					ContactNo = mTVApplicationVM.HelperTelNo,
					BirthDate = mTVApplicationVM.Helperbirthdate
				},
				Driver = new Driver
				{
					FirstName = mTVApplicationVM.DriverFname,
					MiddleName = mTVApplicationVM.DriverMname,
					LastName = mTVApplicationVM.DriverLname,
					LicenseFront = imageLicenseFront,
					LicenseBack = imageLicenseBack,
					Address = mTVApplicationVM.DriverAddress,
					Email = mTVApplicationVM.DriverEmail,
					ContactNo = mTVApplicationVM.DriverTelNo,
					Gender = mTVApplicationVM.gender,
					BirthDate = mTVApplicationVM.Driverbirthdate
				}

			};
                _context.Add(mtv);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "MTVquiz");
            
        }

		//[HttpGet]
		//public async Task<IActionResult> YourSearchAction(string accreditationNumber)
		//{
		//	// Search for the record using the accreditation number
		//	var record = await _context.MTVApplications
		//							   .Where(x => x.AccreditionNo == accreditationNumber)
		//							   .FirstOrDefaultAsync();

			
		//		return View();
			
		//}

		// GET: MTVapplication/Edit/5
		[Authorize(Policy = "RequireMtvUsers")]
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
		[Authorize(Policy = "RequireMtvUsers")]
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
                return Problem("Entity set 'AppDbContext.MTVApplications'  is null.");
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


		[HttpPost]
		public ActionResult GenerateRandomNumber()
		{
			DateTime date = DateTime.Now;
			var mtv = _context.MTVApplications.Count();
			var yearFormatted = (date.Year % 100).ToString("D2");
			var mtvFormatted = mtv.ToString("D4");

			var accreditation = "RTOCXI - " + yearFormatted + " - " + mtvFormatted;
			return Content(accreditation);
		}


        [HttpPost]
        public IActionResult GenerateResult([FromBody] AccreditionViewModel model)
        {
            // Process the data received
            // For example, querying database or any other logic

			var mtvapp = _context.MTVApplications
				.Include(p => p.VehicleInfo)
				.Include(p => p.Driver)
				.Include(p => p.Helper)
				.Where(p => p.AccreditationNo == model.AccreditionNo)
				.FirstOrDefault();

			var mtvappVM = new MtvApplicationViewModel
			{
				OwnerFname = mtvapp.OwnerFirstName,
				OwnerMname = mtvapp.OwnerMiddleName,
				OwnerLname = mtvapp.OwnerLastName,
				//Address
				Email = mtvapp.Email,
				TelNo = mtvapp.ContactNo,
				FaxNo = mtvapp.FaxNo,
				Status = mtvapp.Status,
				VehicleMaker = mtvapp.VehicleInfo.VehicleMaker,
				PlateNo = mtvapp.VehicleInfo.PlateNo,
				EngineNo = mtvapp.VehicleInfo.EngineNo,
				//LTOCR
				//LTOOR
				//EST
				Destination = mtvapp.VehicleInfo.Destination,

				HelperFname = mtvapp.Helper.FirstName,
				HelperMname = mtvapp.Helper.MiddleName,
				HelperLname = mtvapp.Helper.LastName,
				HelperEmail = mtvapp.Helper.Email,
				HelperTelNo = mtvapp.Helper.ContactNo,

				DriverFname = mtvapp.Driver.FirstName,
				DriverMname = mtvapp.Driver.MiddleName,
				DriverLname = mtvapp.Driver.LastName,
				DriverEmail = mtvapp.Driver.Email,
				DriverTelNo = mtvapp.Driver.ContactNo,
				
				//driveremail
				//drivertelno
				

				

			};

			// Return the result back to the frontend
			//return View(mtvappVM);
			return Json(new { result = "Success", data = mtvappVM });
		}


    }
}
