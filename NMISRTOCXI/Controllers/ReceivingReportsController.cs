using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using DomainLayer.Models.ViewModels;
using ServiceLayer.Services.IRepositories;
using AutoMapper;

namespace thesis.Controllers
{
    public class ReceivingReportsController : Controller
	{


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AccountDetails> _userManager;


		public ReceivingReportsController(IUnitOfWork unitOfWork,
			IMapper mapper,
			UserManager<AccountDetails> userManager)
		{
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
		}

		// GET: ReceivingReports
		public async Task<IActionResult> Index()
		{
            ViewBag.AlertMessage = TempData["AlertMessage"] as string;
            var user = await _userManager.GetUserAsync(User);
            var meatDealers = await _unitOfWork.MeatDealers.GetAll(c => c.MeatEstablishmentId == user.MeatEstablishmentId,
				includeProperties: "MeatEstablishment");

			ViewData["MeatDealers"] = meatDealers;
			var meatEstablishments = await _unitOfWork.MeatEstablishment.GetAll(me => me.Name != null);
			ViewData["MeatEstablishments"] = new SelectList(meatEstablishments, "Id", "Name");
			if (User.IsInRole("MeatEstablishmentRepresentative"))
			{
                var receivingReport = await _unitOfWork.ReceivingReport.GetAll(
					c => c.AccountDetails.MeatEstablishmentId == user.MeatEstablishmentId, 
					includeProperties: "AccountDetails,MeatDealers");
			    var receivingReportMapped = _mapper.Map<IEnumerable<ReceivingReportViewModel>>(receivingReport);
                var response = receivingReportMapped.OrderByDescending(r => r.RecTime).ToList();
                return View(response);
            }
            else if (User.IsInRole("MeatInspector"))
			{
                var receivingReport = await _unitOfWork.ReceivingReport.GetAll(c => c.InspectionStatus == InspectionStatus.Pending, 
					includeProperties: "AccountDetails,MeatDealers");
                var receivingReportMapped = _mapper.Map<IEnumerable<ReceivingReportViewModel>>(receivingReport);
                var response = receivingReportMapped.OrderByDescending(r => r.RecTime).ToList();
                return View(response);
            }
			else if(User.IsInRole("InspectorAdmin"))
			{
                var receivingReport = await _unitOfWork.ReceivingReport.GetAll(includeProperties: "AccountDetails,MeatDealers");
                var receivingReportMapped = _mapper.Map<IEnumerable<ReceivingReportViewModel>>(receivingReport);
                var response = receivingReportMapped.OrderByDescending(r => r.RecTime).ToList();
                return View(response);
            }
			return View();
        }


		// GET: ReceivingReports/Details/5
		public async Task<IActionResult> Details(Guid? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}
            var response = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id, includeProperties: "AccountDetails,MeatDealers");
			if (response == null)
			{
				return NotFound();
			}

			return View(response);
		}

		// GET: ReceivingReports/Create
		public async Task<IActionResult> Create()
		{
			var loggedInUserId = _userManager.GetUserId(User); // Replace this with your actual logic to get the logged-in user's ID.
			var loggedInUser = await _unitOfWork.AccountDetails.Get(user => user.Id == loggedInUserId, includeProperties: "MeatEstablishment");
            var meatDealerList = await _unitOfWork.MeatDealers.GetAll(includeProperties: "MeatEstablishment");
            var concatenatedList = new List<SelectListItem>();

			foreach (var meatDealer in meatDealerList)
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

            ViewBag.MeatDealersId = new SelectList(concatenatedList, "Value", "Text");

			var userList = await _unitOfWork.AccountDetails.GetAll();
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

            ViewBag.AccountDetailsId = new SelectList(concatenatedList1, "Value", "Text");
            return View();
		}

		// POST: ReceivingReports/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateReceivingReportViewModel request)
		{
			var response = _mapper.Map<ReceivingReport>(request);
			if (ModelState.IsValid) //not not
			{
				_unitOfWork.ReceivingReport.Add(response);
				await _unitOfWork.Save();
				TempData["AlertMessage"] = "Transaction Success";
				return RedirectToAction(nameof(Index));
			}
			return View(request);
		}

		// GET: ReceivingReports/Edit/5
		public async Task<IActionResult> Edit(Guid? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}

			var receivingReport = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id);
			if (receivingReport == null)
			{
				return NotFound();
			}

            var response = _mapper.Map<EditReceivingReportViewModel>(receivingReport);

            var loggedInUserId = _userManager.GetUserId(User); // Replace this with your actual logic to get the logged-in user's ID.
            var loggedInUser = await _unitOfWork.AccountDetails.Get(user => user.Id == loggedInUserId, includeProperties: "MeatEstablishment");
            var meatDealerList = await _unitOfWork.MeatDealers.GetAll(includeProperties: "MeatEstablishment");
            var concatenatedList = new List<SelectListItem>();

            foreach (var meatDealer in meatDealerList)
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

            ViewBag.MeatDealersId = new SelectList(concatenatedList, "Value", "Text");

            var userList = await _unitOfWork.AccountDetails.GetAll();
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

            ViewBag.AccountDetailsId = new SelectList(concatenatedList1, "Value", "Text");
            var speciesList = EnumSelectListGenerator<Species>.GenerateSelectList();
            ViewBag.Species = new SelectList(speciesList, "Value", "Text");
            var categoryOfFoodAnimalsList = EnumSelectListGenerator<CategoryOfFoodAnimals>.GenerateSelectList();
            ViewBag.CategoryOfFoodAnimals = new SelectList(categoryOfFoodAnimalsList, "Value", "Text");
            var inspectionStatusList = EnumSelectListGenerator<InspectionStatus>.GenerateSelectList();
            ViewBag.InspectionStatus = new SelectList(inspectionStatusList, "Value", "Text");
            return View(response);
		}

		// POST: ReceivingReports/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditReceivingReportViewModel request)
		{
			var existingEntity = await _unitOfWork.ReceivingReport.Get(c => c.Id == request.Id);
			_mapper.Map(request, existingEntity);

			if (ModelState.IsValid)
			{

                _unitOfWork.ReceivingReport.Update(existingEntity);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
			}

			TempData["AlertMessage"] = "Transaction Success";
			return View(request);
		}

		// GET: ReceivingReports/Delete/5
		public async Task<IActionResult> Delete(Guid? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}

			var receivingReport = await _unitOfWork.ReceivingReport.GetAll(c => c.Id == Id, includeProperties: "AccountDetails,MeatDealers");
			if (receivingReport == null)
			{
				return NotFound();
			}

			return View(receivingReport);
		}

		// POST: ReceivingReports/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid Id)
		{
			var receivingReport = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id);
			if (receivingReport != null)
			{
				_unitOfWork.ReceivingReport.Remove(receivingReport);
			}

			await _unitOfWork.Save();
			TempData["AlertMessage"] = "Transaction Success";
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> ActionResult(Guid Id)
		{
			// Use the Id value as needed
			var result = new MeatInspectionReport
			{
				ReceivingReportId = Id,
				RepDate = DateTime.Now,
			};

			_unitOfWork.MeatInspectionReport.Add(result);
			await _unitOfWork.Save();

			// Retrieve the MeatInspectionReportId after it is saved
			int meatInspectionReportId = result.Id;

            // Redirect to the Create action of ConductOfInspections controller and pass the MeatInspectionReportId
            return RedirectToAction("Create", "ConductOfInspections", new { meatInspectionReportId });

		}



	}
}

