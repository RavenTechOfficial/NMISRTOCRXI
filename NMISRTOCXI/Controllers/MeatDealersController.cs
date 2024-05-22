using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Services.IRepositories;
using AutoMapper;
using DomainLayer.Models.ViewModels;


namespace NMISRTOCXI.Controllers
{
	//[Authorize(Policy = "RequireInspectorAdmin")]
	public class MeatDealersController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly UserManager<AccountDetails> _userManager; // Add the type argument 'AccountDetails'
		public MeatDealersController(IUnitOfWork unitOfWork,
			IMapper mapper,
			UserManager<AccountDetails> userManager)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_userManager = userManager;
		}

		// GET: MeatDealers
		public async Task<IActionResult> Index()
		{
			ViewBag.AlertMessage = TempData["AlertMessage"] as string;
			var user = await _userManager.GetUserAsync(User);
			var meatDealer = await _unitOfWork.MeatDealers.GetAll(c => c.MeatEstablishmentId == user.MeatEstablishmentId, includeProperties: "MeatEstablishment");
			var response = _mapper.Map<IEnumerable<AccountDetailsViewModel>>(meatDealer);
			return View(response);
		}

		// GET: MeatDealers/Details/5
		public async Task<IActionResult> Details(Guid? Id)
		{
			if (Id == null) return NotFound();

			var meatDealer = await _unitOfWork.MeatDealers.Get(m => m.Id == Id);
			if (meatDealer == null) return NotFound();

			var response = _mapper.Map<AccountDetailsViewModel>(meatDealer);

			return View(response);
		}
		// GET: MeatDealers/Create
		public async Task<IActionResult> Create()
		{
			var currentUser = await _userManager.GetUserAsync(User);

			if (currentUser == null || currentUser.MeatEstablishmentId == null)
			{
				return BadRequest("User is not associated with any MeatEstablishment.");
			}

			var response = await _unitOfWork.MeatEstablishment.GetAll(c => c.Id == currentUser.MeatEstablishmentId);

			ViewBag.MeatEstablishmentList = new SelectList(response, "Id", "Name");

			return View();
		}

		// POST: MeatDealers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Address,ContactNo,MeatEstablishmentId")] MeatDealers meatDealers)
		public async Task<IActionResult> Create(CreateMeatDealersViewModel request)
		{
			if (ModelState.IsValid)
			{
				var response = _mapper.Map<MeatDealers>(request);
				_unitOfWork.MeatDealers.Add(response);
				await _unitOfWork.Save();
				TempData["AlertMessage"] = "Transaction Success";
				return RedirectToAction(nameof(Index));
			}
			return View(request);
		}

        // GET: MeatDealers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (id == null) return NotFound();

            var existingEntity = await _unitOfWork.MeatDealers.Get(c => c.Id == id);

            if (existingEntity == null) return NotFound();

            var response = _mapper.Map<EditMeatDealersViewModel>(existingEntity);

            var responseME = await _unitOfWork.MeatEstablishment.GetAll(c => c.Id == currentUser.MeatEstablishmentId);

            ViewBag.MeatEstablishmentList = new SelectList(responseME, "Id", "Name");

            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMeatDealersViewModel request)
        {
            if (ModelState.IsValid)
            {
                var existingEntity = await _unitOfWork.MeatDealers.Get(c => c.Id == request.Id);

                if (existingEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(request, existingEntity); // Map the updated fields from the request to the existing entity
                _unitOfWork.MeatDealers.Update(existingEntity);
                await _unitOfWork.Save();

                TempData["AlertMessage"] = "Transaction Success";
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        // GET: MeatDealers/Delete/5
        public async Task<IActionResult> Delete(Guid? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}

			var response = await _unitOfWork.MeatDealers.Get(c => c.Id == Id);

			if (response == null) return NotFound();

			return View(response);
		}

		// POST: MeatDealers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid Id)
		{
			var response = await _unitOfWork.MeatDealers.Get(c => c.Id == Id);
			if (response != null)
			{
				_unitOfWork.MeatDealers.Remove(response);
				TempData["AlertMessage"] = "Transaction Success";
			}

			await _unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}