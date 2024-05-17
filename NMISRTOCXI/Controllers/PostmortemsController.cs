using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace thesis.Controllers
{
	public class PostmortemsController : Controller
	{
		private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostmortemsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
            _webHostEnvironment = webHostEnvironment;
        }

		// GET: Postmortems
		public async Task<IActionResult> Index(int myVariable)
		{

			ViewBag.AlertMessage = TempData["AlertMessage"] as string;
			ViewBag.AlertMessagee = TempData["AlertMessagee"] as string;
			ViewBag.MyVariable = myVariable;

			var viewModel = new PostmortemViewModel();

			viewModel.Postmortem = await _context.Postmortems
				.Include(c => c.PassedForSlaughter)
				.Where(c => c.PassedForSlaughterId == myVariable)
				.ToListAsync();

			ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id");

			return View("Index", viewModel.Postmortem);

			//ViewBag.MyVariable = myVariable;
			//var AppDbContext = _context.Postmortems
			//    .Include(c => c.PassedForSlaughter)
			//   .Where(c => c.PassedForSlaughterId == myVariable)
			//   .ToListAsync();
			////var AppDbContext = _context.Postmortems.Include(p => p.PassedForSlaughter);

			//return View();
		}

		// GET: Postmortems/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Postmortems == null)
			{
				return NotFound();
			}

			var postmortem = await _context.Postmortems
				.Include(p => p.PassedForSlaughter)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (postmortem == null)
			{
				return NotFound();
			}

			return View(postmortem);
		}

		// GET: Postmortems/Create
		public IActionResult Create()
		{
			var viewModel = new PostmortemViewModel
			{
				Postmortem = _context.Postmortems.Include(p => p.PassedForSlaughter).ToList(),
				// Populate any other necessary properties of the viewModel object
			};

			// Fetch the latest PassedForSlaughterId
			int latestPassedForSlaughterId = _context.PassedForSlaughters
				.OrderByDescending(pfs => pfs.Id)
				.Select(pfs => pfs.Id)
				.FirstOrDefault();

			ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id", latestPassedForSlaughterId);
			ViewData["LatestPassedForSlaughterId"] = latestPassedForSlaughterId;
			return View(viewModel);
		}


		// POST: Postmortems/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Postmortem postmortem)
		{
   //         var image1 = "";
   //         if (postmortemVM.Image1 != null && postmortemVM.Image1.Length > 0)
   //         {
   //             var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(postmortemVM.Image1.FileName)}";
   //             var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/condemnedMeat", uniqueFileName);
   //             image1 = uniqueFileName;

   //             using (var fileStream = new FileStream(filePath, FileMode.Create))
   //             {
   //                 await postmortemVM.Image1.CopyToAsync(fileStream);
   //             }
   //         }

   //         var image2 = "";
   //         if (postmortemVM.Image2 != null && postmortemVM.Image2.Length > 0)
   //         {
   //             var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(postmortemVM.Image2.FileName)}";
   //             var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/condemnedMeat", uniqueFileName);
   //             image2 = uniqueFileName;

   //             using (var fileStream = new FileStream(filePath, FileMode.Create))
   //             {
   //                 await postmortemVM.Image2.CopyToAsync(fileStream);
   //             }
   //         }

   //         var image3 = "";
   //         if (postmortemVM.Image3 != null && postmortemVM.Image3.Length > 0)
   //         {
   //             var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(postmortemVM.Image3.FileName)}";
   //             var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/condemnedMeat", uniqueFileName);
   //             image3 = uniqueFileName;

   //             using (var fileStream = new FileStream(filePath, FileMode.Create))
   //             {
   //                 await postmortemVM.Image3.CopyToAsync(fileStream);
   //             }
   //         }

   //         var postmortem = new Postmortem
			//{
			//	PassedForSlaughterId = postmortemVM.PassedForSlaughterId,
			//	PassedForSlaughter = postmortemVM.PassedForSlaughter,
			//	AnimalPart = postmortemVM.AnimalPart,
			//	Cause = postmortemVM.Cause,
			//	Weight = postmortemVM.Weight,
			//	NoOfHeads = postmortemVM.NoOfHeads,
			//	Image1 = image1,
			//	Image2 = image2,
			//	Image3 = image3,
			//};


			if (ModelState.IsValid)
			{
				_context.Add(postmortem);
				await _context.SaveChangesAsync();

				TempData["AlertMessage"] = "Transaction Success";
				TempData["PassedForSlaughterId"] = postmortem.PassedForSlaughterId;
				return RedirectToAction("Index", new { myVariable = postmortem.PassedForSlaughterId });
				//  return RedirectToAction("Create", "TotalNoFitForHumanConsumptions");
			}
			ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);

			return View(postmortem);
		}

		// GET: Postmortems/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Postmortems == null)
			{
				return NotFound();
			}

			var postmortem = await _context.Postmortems.FindAsync(id);
			if (postmortem == null)
			{
				return NotFound();
			}
			ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);
			return View(postmortem);
		}

		// POST: Postmortems/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,PassedForSlaughterId,AnimalPart,Cause,Weight,NoOfHeads,Image1, Image2, Image3")] Postmortem postmortem)
		{
			if (id != postmortem.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(postmortem);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PostmortemExists(postmortem.Id))
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
			ViewData["PassedForSlaughterId"] = new SelectList(_context.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);
			return View(postmortem);
		}

		// GET: Postmortems/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Postmortems == null)
			{
				return NotFound();
			}

			var postmortem = await _context.Postmortems
				.Include(p => p.PassedForSlaughter)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (postmortem == null)
			{
				return NotFound();
			}

			return View(postmortem);
		}

		// POST: Postmortems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Postmortems == null)
			{
				return Problem("Entity set 'AppDbContext.Postmortems'  is null.");
			}
			var postmortem = await _context.Postmortems.FindAsync(id);
			if (postmortem != null)
			{
				_context.Postmortems.Remove(postmortem);
			}

			await _context.SaveChangesAsync();
			TempData["AlertMessage"] = "Transaction Success";
			return RedirectToAction(nameof(Index));
		}

		private bool PostmortemExists(int id)
		{
			return (_context.Postmortems?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
