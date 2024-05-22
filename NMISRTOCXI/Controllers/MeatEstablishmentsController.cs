using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models.ViewModels;
using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;
using AutoMapper;
using DomainLayer.Enum;
using ServiceLayer.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace NMISRTOCXI.Controllers
{
	[Authorize(Policy = "RequireInspectorAdmin")]
	public class MeatEstablishmentsController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public MeatEstablishmentsController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		// GET: MeatEstablishments
		public async Task<IActionResult> Index()
		{
			ViewBag.AlertMessage = TempData["AlertMessage"] as string;

			var meatEstablishments = await _unitOfWork.MeatEstablishment.GetAll();
			var response = _mapper.Map<IEnumerable<MeatEstablishmentViewModel>>(meatEstablishments);
			return View(response);
		}

		// GET: MeatEstablishments/Details/5
		public async Task<IActionResult> Details(Guid? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}

			var meatEstablishment = await _unitOfWork.MeatEstablishment.Get(c => c.Id == Id);
			var response = _mapper.Map<MeatEstablishmentViewModel>(meatEstablishment);
			return View(response);
		}

		// GET: MeatEstablishments/Create
		public IActionResult Create()
        {
            var establishmentTypesList = EnumSelectListGenerator<EstablishmentType>.GenerateSelectList();
            var licenseStatusList = EnumSelectListGenerator<LicenseStatus>.GenerateSelectList();
            ViewBag.EstablishmentTypesList = new SelectList(establishmentTypesList, "Value", "Text");
            ViewBag.LicenseStatusList = new SelectList(licenseStatusList, "Value", "Text");
            return View();
		}

		// POST: MeatEstablishments/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateMeatEstablishmentViewModel request)
		{
			var response = _mapper.Map<MeatEstablishment>(request);
			if (ModelState.IsValid)
			{

				_unitOfWork.MeatEstablishment.Add(response);
				await _unitOfWork.Save();
				TempData["AlertMessage"] = "Transaction Success";

				return RedirectToAction(nameof(Index));
			}

			return View(request);
		}


        // GET: MeatEstablishments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {

            var existingEntity = await _unitOfWork.MeatEstablishment.Get(c => c.Id == id);

            if (existingEntity == null) return NotFound();

            var response = _mapper.Map<EditMeatEstablishmentViewModel>(existingEntity);
            var establishmentTypesList = EnumSelectListGenerator<EstablishmentType>.GenerateSelectList();
            var licenseStatusList = EnumSelectListGenerator<LicenseStatus>.GenerateSelectList();

			ViewBag.EstablishmentTypesList = new SelectList(establishmentTypesList, "Value", "Text");
            ViewBag.LicenseStatusList = new SelectList(licenseStatusList, "Value", "Text");

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMeatEstablishmentViewModel request)
        {
            if (ModelState.IsValid)
            {
                var existingEntity = await _unitOfWork.MeatEstablishment.Get(c => c.Id == request.Id);

                if (existingEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(request, existingEntity); 
                _unitOfWork.MeatEstablishment.Update(existingEntity);
                await _unitOfWork.Save();

                TempData["AlertMessage"] = "Transaction Success";
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

		// GET: MeatEstablishments/Delete/5
		public async Task<IActionResult> Delete(Guid? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}

			var response = await _unitOfWork.MeatEstablishment.Get(c => c.Id == Id);

			if (response == null) return NotFound();

			return View(response);
		}

		// POST: MeatEstablishments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid? Id)
		{
			var response = await _unitOfWork.MeatEstablishment.Get(c => c.Id == Id);
			if (response != null)
			{
				_unitOfWork.MeatEstablishment.Remove(response);
				TempData["AlertMessage"] = "Transaction Success";
			}

			await _unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}