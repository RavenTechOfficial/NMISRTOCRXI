using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models;
using DomainLayer.Enum;
using ServiceLayer.Services.IRepositories;

namespace NMISRTOCXI.Controllers
{
    public class PostmortemsController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public PostmortemsController(IUnitOfWork context, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = context;
			_webHostEnvironment = webHostEnvironment;
		}


        [HttpPost]
        public IActionResult UploadImages(List<IFormFile> images, string filename)
        {
            var imagePaths = new List<string>();
            var imageNumber = 1;
            foreach (var image in images)
            {
                if (image != null && image.Length > 0)
                {
                    // Construct the unique filename by appending the imageNumber to the provided filename
                    var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
                    var filePath = Path.Combine("wwwroot/img/PostmortemImages", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    imagePaths.Add(filePath);
                    imageNumber++;
                }
            }

            var response = new
            {
                success = true,
                image1 = imagePaths.Count > 0 ? imagePaths[0] : null,
                image2 = imagePaths.Count > 1 ? imagePaths[1] : null,
                image3 = imagePaths.Count > 2 ? imagePaths[2] : null
            };

            return Json(response);
        }



        // ADD BUTTON // add row to post table 
        [HttpPost]
        public async Task<IActionResult> Create(Guid Id, int postPart, int postCause, double postWeight, int postHead, List<IFormFile> images)
        {

            var result = new Postmortem
            {
                ReceivingReportId = Id,
                AnimalPart = (AnimalPart)postPart,
                Cause = (Cause)postCause,
                Weight = postWeight,
                NoOfHeads = postHead,
            };
            _unitOfWork.Postmortem.Add(result);
            await _unitOfWork.Save();

            var postmortem = await _unitOfWork.Postmortem
                .GetAll(p => p.ReceivingReportId == Id);

            var totalNoOfHeads = postmortem.Sum(p => p.NoOfHeads);
            var totalWeight = postmortem.Sum(p => p.Weight);

            var filename = Id + "-" + result.Id + "-" + postPart + "-" + postCause + "-img";

            var imagePaths = new List<string>();
            var imageNumber = 1;
            foreach (var image in images)
            {
                if (image != null && image.Length > 0)
                {
                    // Construct the unique filename by appending the imageNumber to the provided filename
                    var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
                    var filePath = Path.Combine($"wwwroot/img/PostmortemImages/{postPart}/{postCause}", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    imagePaths.Add(filePath);
                    imageNumber++;
                }
            }
            var uploadresponse = new
            {
                success = true,
                image1 = imagePaths.Count > 0 ? imagePaths[0] : null,
                image2 = imagePaths.Count > 1 ? imagePaths[1] : null,
                image3 = imagePaths.Count > 2 ? imagePaths[2] : null
            };

            var existingPostmortem = await _unitOfWork.Postmortem.Get(c => c.Id == result.Id);

            existingPostmortem.Image1 = uploadresponse.image1;
            existingPostmortem.Image2 = uploadresponse.image2;
            existingPostmortem.Image3 = uploadresponse.image3;

            // Save the changes to the database
            _unitOfWork.Postmortem.Update(existingPostmortem);
            await _unitOfWork.Save();

            var response = new
            {
                success = true,
                issue = result.AnimalPart.ToString(),
                cause = result.Cause.ToString(),
                head = result.NoOfHeads,
                weight = result.Weight,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,
                image1 = uploadresponse.image1,
                image2 = uploadresponse.image2,
                image3 = uploadresponse.image3
            };

            return Json(response);
        }

        // Postmortem Delete
        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id, int postRowId)
        {

            var entityToDelete = await _unitOfWork.Postmortem.Get(c => c.Id == postRowId);

            // Get file paths from the Postmortem entity
            var imagePaths = new List<string>
            {
                entityToDelete.Image1,
                entityToDelete.Image2,
                entityToDelete.Image3
            };


            DeleteImageFiles(imagePaths);

            _unitOfWork.Postmortem.Remove(entityToDelete);
            await _unitOfWork.Save();

            var data = await _unitOfWork.Postmortem
                             .GetAll(c => c.ReceivingReportId == Id);

            var totalNoOfHeads = data.Sum(c => c.NoOfHeads);

            var totalWeight = data.Sum(c => c.Weight);

            var response = new
            {
                success = true,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,
                firstPostId = data

            };
            return Json(data);
        }

        private void DeleteImageFiles(List<string> imagePaths)
        {
            try
            {
                foreach (var imagePath in imagePaths)
                {
                    if (!string.IsNullOrEmpty(imagePath))
                    {



                        if (System.IO.File.Exists(imagePath))
                        {

                            System.IO.File.Delete(imagePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        // Edit row in postmortem 

        public async Task<IActionResult> Edit(Guid Id, int postRowId, int postHead, double postWeight, int postPart, int postCause, List<string> imagePaths, List<IFormFile> images)
        {

            DeleteImageFiles(imagePaths);


            var filename = Id + "-" + postRowId + "-" + postPart + "-" + postCause + "-img";

            var imagePath = new List<string>();
            var imageNumber = 1;
            foreach (var image in images)
            {
                if (image != null && image.Length > 0)
                {
                    // Construct the unique filename by appending the imageNumber to the provided filename
                    var uniqueFileName = $"{filename}{imageNumber}{Path.GetExtension(image.FileName)}";
                    var filePath = Path.Combine($"wwwroot/img/PostmortemImages/{postPart}/{postCause}", uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    imagePath.Add(filePath);
                    imageNumber++;
                }
            }
            var uploadresponse = new
            {
                success = true,
                image1 = imagePath.Count > 0 ? imagePath[0] : null,
                image2 = imagePath.Count > 1 ? imagePath[1] : null,
                image3 = imagePath.Count > 2 ? imagePath[2] : null
            };

            var existingPostmortem = await _unitOfWork.Postmortem.Get(c => c.Id == postRowId);


            existingPostmortem.AnimalPart = (AnimalPart)postPart;
            existingPostmortem.NoOfHeads = postHead;
            existingPostmortem.Weight = postWeight;
            existingPostmortem.Cause = (Cause)postCause;
            existingPostmortem.Image1 = uploadresponse.image1;
            existingPostmortem.Image2 = uploadresponse.image2;
            existingPostmortem.Image3 = uploadresponse.image3;

            // Save the changes to the database
            await _unitOfWork.Save();

            var enumPart = (AnimalPart)postPart;
            var enumCause = (Cause)postCause;

            var postmortem = await _unitOfWork.Postmortem
                .GetAll(c => c.ReceivingReportId == Id);
            var totalNoOfHeads = postmortem.Sum(c => c.NoOfHeads);
            var totalWeight = postmortem.Sum(c => c.Weight);

            var response = new
            {
                success = true,
                postPart = enumPart.ToString(),
                postCause = enumCause.ToString(),
                postHead = postHead,
                postWeight = postWeight,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,
                image1 = uploadresponse.image1,
                image2 = uploadresponse.image2,
                image3 = uploadresponse.image3

            };

            return Json(response);
        }
        //// GET: Postmortems
        //public async Task<IActionResult> Index(int myVariable)
        //{

        //	ViewBag.AlertMessage = TempData["AlertMessage"] as string;
        //	ViewBag.AlertMessagee = TempData["AlertMessagee"] as string;
        //	ViewBag.MyVariable = myVariable;

        //	var viewModel = new PostmortemViewModel();

        //	viewModel.Postmortem = await _unitOfWork.Postmortems
        //		.Include(c => c.PassedForSlaughter)
        //		.Where(c => c.PassedForSlaughterId == myVariable)
        //		.ToListAsync();

        //	ViewData["PassedForSlaughterId"] = new SelectList(_unitOfWork.PassedForSlaughters, "Id", "Id");

        //	return View("Index", viewModel.Postmortem);

        //	//ViewBag.MyVariable = myVariable;
        //	//var IUnitOfWork = _unitOfWork.Postmortems
        //	//    .Include(c => c.PassedForSlaughter)
        //	//   .Where(c => c.PassedForSlaughterId == myVariable)
        //	//   .ToListAsync();
        //	////var IUnitOfWork = _unitOfWork.Postmortems.Include(p => p.PassedForSlaughter);

        //	//return View();
        //}

        //// GET: Postmortems/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //	if (id == null || _unitOfWork.Postmortems == null)
        //	{
        //		return NotFound();
        //	}

        //	var postmortem = await _unitOfWork.Postmortems
        //		.Include(p => p.PassedForSlaughter)
        //		.FirstOrDefaultAsync(m => m.Id == id);
        //	if (postmortem == null)
        //	{
        //		return NotFound();
        //	}

        //	return View(postmortem);
        //}

        //// GET: Postmortems/Create
        //public IActionResult Create()
        //{
        //	var viewModel = new PostmortemViewModel
        //	{
        //		Postmortem = _unitOfWork.Postmortems.Include(p => p.PassedForSlaughter).ToList(),
        //		// Populate any other necessary properties of the viewModel object
        //	};

        //	// Fetch the latest PassedForSlaughterId
        //	int latestPassedForSlaughterId = _unitOfWork.PassedForSlaughters
        //		.OrderByDescending(pfs => pfs.Id)
        //		.Select(pfs => pfs.Id)
        //		.FirstOrDefault();

        //	ViewData["PassedForSlaughterId"] = new SelectList(_unitOfWork.PassedForSlaughters, "Id", "Id", latestPassedForSlaughterId);
        //	ViewData["LatestPassedForSlaughterId"] = latestPassedForSlaughterId;
        //	return View(viewModel);
        //}


        //// POST: Postmortems/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Postmortem postmortem)
        //{
        //	//         var image1 = "";
        //	//         if (postmortemVM.Image1 != null && postmortemVM.Image1.Length > 0)
        //	//         {
        //	//             var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(postmortemVM.Image1.FileName)}";
        //	//             var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/condemnedMeat", uniqueFileName);
        //	//             image1 = uniqueFileName;

        //	//             using (var fileStream = new FileStream(filePath, FileMode.Create))
        //	//             {
        //	//                 await postmortemVM.Image1.CopyToAsync(fileStream);
        //	//             }
        //	//         }

        //	//         var image2 = "";
        //	//         if (postmortemVM.Image2 != null && postmortemVM.Image2.Length > 0)
        //	//         {
        //	//             var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(postmortemVM.Image2.FileName)}";
        //	//             var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/condemnedMeat", uniqueFileName);
        //	//             image2 = uniqueFileName;

        //	//             using (var fileStream = new FileStream(filePath, FileMode.Create))
        //	//             {
        //	//                 await postmortemVM.Image2.CopyToAsync(fileStream);
        //	//             }
        //	//         }

        //	//         var image3 = "";
        //	//         if (postmortemVM.Image3 != null && postmortemVM.Image3.Length > 0)
        //	//         {
        //	//             var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(postmortemVM.Image3.FileName)}";
        //	//             var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/condemnedMeat", uniqueFileName);
        //	//             image3 = uniqueFileName;

        //	//             using (var fileStream = new FileStream(filePath, FileMode.Create))
        //	//             {
        //	//                 await postmortemVM.Image3.CopyToAsync(fileStream);
        //	//             }
        //	//         }

        //	//         var postmortem = new Postmortem
        //	//{
        //	//	PassedForSlaughterId = postmortemVM.PassedForSlaughterId,
        //	//	PassedForSlaughter = postmortemVM.PassedForSlaughter,
        //	//	AnimalPart = postmortemVM.AnimalPart,
        //	//	Cause = postmortemVM.Cause,
        //	//	Weight = postmortemVM.Weight,
        //	//	NoOfHeads = postmortemVM.NoOfHeads,
        //	//	Image1 = image1,
        //	//	Image2 = image2,
        //	//	Image3 = image3,
        //	//};


        //	if (ModelState.IsValid)
        //	{
        //		_unitOfWork.Add(postmortem);
        //		await _unitOfWork.SaveChangesAsync();

        //		TempData["AlertMessage"] = "Transaction Success";
        //		TempData["PassedForSlaughterId"] = postmortem.PassedForSlaughterId;
        //		return RedirectToAction("Index", new { myVariable = postmortem.PassedForSlaughterId });
        //		//  return RedirectToAction("Create", "TotalNoFitForHumanConsumptions");
        //	}
        //	ViewData["PassedForSlaughterId"] = new SelectList(_unitOfWork.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);

        //	return View(postmortem);
        //}

        //// GET: Postmortems/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //	if (id == null || _unitOfWork.Postmortems == null)
        //	{
        //		return NotFound();
        //	}

        //	var postmortem = await _unitOfWork.Postmortems.FindAsync(id);
        //	if (postmortem == null)
        //	{
        //		return NotFound();
        //	}
        //	ViewData["PassedForSlaughterId"] = new SelectList(_unitOfWork.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);
        //	return View(postmortem);
        //}

        //// POST: Postmortems/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,PassedForSlaughterId,AnimalPart,Cause,Weight,NoOfHeads,Image1, Image2, Image3")] Postmortem postmortem)
        //{
        //	if (id != postmortem.Id)
        //	{
        //		return NotFound();
        //	}

        //	if (ModelState.IsValid)
        //	{
        //		try
        //		{
        //			_unitOfWork.Update(postmortem);
        //			await _unitOfWork.SaveChangesAsync();
        //		}
        //		catch (DbUpdateConcurrencyException)
        //		{
        //			if (!PostmortemExists(postmortem.Id))
        //			{
        //				return NotFound();
        //			}
        //			else
        //			{
        //				throw;
        //			}
        //		}
        //		return RedirectToAction(nameof(Index));
        //	}

        //	TempData["AlertMessage"] = "Transaction Success";
        //	ViewData["PassedForSlaughterId"] = new SelectList(_unitOfWork.PassedForSlaughters, "Id", "Id", postmortem.PassedForSlaughterId);
        //	return View(postmortem);
        //}

        //// GET: Postmortems/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //	if (id == null || _unitOfWork.Postmortems == null)
        //	{
        //		return NotFound();
        //	}

        //	var postmortem = await _unitOfWork.Postmortems
        //		.Include(p => p.PassedForSlaughter)
        //		.FirstOrDefaultAsync(m => m.Id == id);
        //	if (postmortem == null)
        //	{
        //		return NotFound();
        //	}

        //	return View(postmortem);
        //}

        //// POST: Postmortems/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //	if (_unitOfWork.Postmortems == null)
        //	{
        //		return Problem("Entity set 'IUnitOfWork.Postmortems'  is null.");
        //	}
        //	var postmortem = await _unitOfWork.Postmortems.FindAsync(id);
        //	if (postmortem != null)
        //	{
        //		_unitOfWork.Postmortems.Remove(postmortem);
        //	}

        //	await _unitOfWork.SaveChangesAsync();
        //	TempData["AlertMessage"] = "Transaction Success";
        //	return RedirectToAction(nameof(Index));
        //}

        //private bool PostmortemExists(int id)
        //{
        //	return (_unitOfWork.Postmortems?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
