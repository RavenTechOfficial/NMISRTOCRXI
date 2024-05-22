using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DomainLayer.Enum;
using DomainLayer.Models.ViewModels;
using ServiceLayer.Services.IRepositories;
using AutoMapper;
using System.Linq;

namespace NMISRTOCXI.Controllers
{

    public class ReceivingReportsController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ReceivingReportsController> _logger;
        private readonly UserManager<AccountDetails> _userManager;

        public ReceivingReportsController(IUnitOfWork unitOfWork,
			IMapper mapper,
            ILogger<ReceivingReportsController> logger,
            UserManager<AccountDetails> userManager)
		{
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
        }

		public async Task<IActionResult> DailyInspection()
		{
			var user = await _userManager.GetUserAsync(User);
			var meatEstablishmentId = user.MeatEstablishmentId;
			IEnumerable<MeatEstablishment> meatEstablishments = Enumerable.Empty<MeatEstablishment>();
			if (User.IsInRole("MeatEstablishmentRepresentative") || User.IsInRole("MeatInspector"))
			{
				meatEstablishments = await _unitOfWork.MeatEstablishment.GetAll(c => c.Id == meatEstablishmentId);

			}
			else if (User.IsInRole("InspectorAdmin"))
			{
				meatEstablishments = await _unitOfWork.MeatEstablishment.GetAll();
			}

			ViewBag.MeatEstablishments = new SelectList(meatEstablishments, "Id", "Name");

			var reportsInfo = await _unitOfWork.ReceivingReport.GetAll();

			// Sort the reportsInfo list by CreatedAt in descending order
			var sortedReportsInfo = reportsInfo.OrderByDescending(item => item.MeatInspectionReport.RepDate).ToList();

			return View(sortedReportsInfo);
		}


		[HttpPost]
        public async Task<IActionResult> Release(Guid Id)
        {
            var receivingReport = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id);
            receivingReport.InspectionStatus = InspectionStatus.Released;

            _unitOfWork.ReceivingReport.Update(receivingReport);
            await _unitOfWork.Save();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Frozen(Guid Id)
        {
            var receivingReport = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id);
            receivingReport.InspectionStatus = InspectionStatus.Frozen;

            _unitOfWork.ReceivingReport.Update(receivingReport);
            await _unitOfWork.Save();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Notification()
        {
            var loggedInUserId = _userManager.GetUserId(User);
                var receivingReport = await _unitOfWork.ReceivingReport.GetAll(c => c.AccountDetailsId == loggedInUserId && c.InspectionStatus == InspectionStatus.Returned);

            var notification = new NotificationViewModel
            {
                NotificationCount = receivingReport.Count(),

            };

            return View(notification);
        }

        [HttpPost]
        public async Task<IActionResult> Return(Guid receivingId, DateTime dateInspected, string inspectionRemarks, InspectionStatus status)
        {
            var loggedInUserId = _userManager.GetUserId(User);

            var receivingReport = await _unitOfWork.ReceivingReport.Get(c => c.Id == receivingId, includeProperties: "MeatInspectionReport");
            if (receivingReport == null)
            {
                return NotFound(new { message = "Receiving report not found." });
            }

            receivingReport.InspectionStatus = status;

            if (receivingReport.MeatInspectionReport != null)
            {
                receivingReport.MeatInspectionReport.Remarks = inspectionRemarks;
            }
            else
            {
                receivingReport.MeatInspectionReport = new MeatInspectionReport
                {
                    Remarks = inspectionRemarks,
                    RepDate = dateInspected,
                    AccountDetailsId = loggedInUserId,
                    UID = Guid.NewGuid(),
                };
            }

            _unitOfWork.ReceivingReport.Update(receivingReport);
            await _unitOfWork.Save();

            var response = _mapper.Map<ReceivingReportViewModel>(receivingReport);

            return RedirectToAction("Index", response);
        }
        [HttpGet]
        public async Task<IActionResult> Inspect(Guid? Id, bool jsonResponse = false)
        {
            if (Id == null)
            {
                _logger.LogError("Id is null");
                if (jsonResponse)
                {
                    return Json(new { success = false, message = "Id is null" });
                }
                return NotFound("Id is null");
            }

            _logger.LogInformation("Method called with Id: {Id}", Id);

            var receivingReport = await _unitOfWork.ReceivingReport.Get(
                c => c.Id == Id,
                includeProperties: "MeatDealers,AccountDetails,MeatInspectionReport,MeatInspectionReport.AccountDetails," +
                "Antemortems,PassedForSlaughter,Postmortems,TotalNoFitForHumanConsumption"
            );

            if (receivingReport == null)
            {
                _logger.LogError("Receiving report not found for Id: {Id}", Id);
                if (jsonResponse)
                {
                    return Json(new { success = false, message = "Receiving report not found" });
                }
                return NotFound("Receiving report not found");
            }

            var totalNoOfHeads = receivingReport.Antemortems?.Sum(c => c.NoOfHeads) ?? 0;
            var totalWeight = receivingReport.Antemortems?.Sum(c => c.Weight) ?? 0;

            var receivingReportMapped = _mapper.Map<ReceivingReportViewModel>(receivingReport);
            _logger.LogInformation("Receiving report mapped successfully for Id: {Id}", Id);

            if (jsonResponse)
            {
                var result = new
                {
                    Data = receivingReportMapped,
                    TotalNoOfHeads = totalNoOfHeads,
                    TotalWeight = totalWeight
                };
                return Json(result);
            }
            else
            {
                return View(receivingReportMapped);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            // Retrieve receiving reports based on user's role
            IEnumerable<ReceivingReport> receivingReport;
            if (User.IsInRole("MeatEstablishmentRepresentative"))
                receivingReport = await _unitOfWork.ReceivingReport.GetAll(
                    c => c.AccountDetails.MeatEstablishmentId == loggedInUser.MeatEstablishmentId,
                    includeProperties: "AccountDetails,MeatDealers,MeatInspectionReport.AccountDetails");
            else if (User.IsInRole("MeatInspector"))
                receivingReport = await _unitOfWork.ReceivingReport.GetAll(
                    c => c.AccountDetails.MeatEstablishmentId == loggedInUser.MeatEstablishmentId,
                    includeProperties: "AccountDetails,MeatDealers,MeatInspectionReport.AccountDetails");
            else if (User.IsInRole("InspectorAdmin"))
                receivingReport = await _unitOfWork.ReceivingReport.GetAll(
                    includeProperties: "AccountDetails,MeatDealers,MeatInspectionReport.AccountDetails");
            else
                return View();

            // Map receiving reports to view models
            var receivingReportMapped = _mapper.Map<IEnumerable<ReceivingReportViewModel>>(receivingReport);

            // Order the mapped receiving reports by RecTime and convert to list
            var response = receivingReportMapped.OrderByDescending(r => r.RecTime).ToList();
            return View(response);
        }

        // GET: ReceivingReports/Details/5
        public async Task<IActionResult> Details(Guid? Id)
		{
			if (Id == null)
			{
				TempData["error"] = "Id not found.";
                return NotFound();
			}
            var response = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id, includeProperties: "AccountDetails,MeatDealers");
			if (response == null)
            {
                TempData["error"] = "Receiving report not found.";
                return NotFound();
			}

			return View(response);
		}

		// GET: ReceivingReports/Create
		public async Task<IActionResult> Create()
		{
			var loggedInUserId = _userManager.GetUserId(User); // Replace this with your actual logic to get the logged-in user's ID.
			var loggedInUser = await _unitOfWork.AccountDetails.Get(user => user.Id == loggedInUserId, includeProperties: "MeatEstablishment");
            var meatDealerList = await _unitOfWork.MeatDealers.GetAll(
				c => c.MeatEstablishmentId == loggedInUser.MeatEstablishmentId, 
				includeProperties: "MeatEstablishment");
			var meatDealers = meatDealerList.Select(c => new
			{
                Id = c.Id,
				FullName = $"{c.FirstName} {c.LastName}"
            });
            ViewBag.MeatDealersId = new SelectList(meatDealers, "Id", "FullName");

            return View();
		}

        // POST: ReceivingReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateReceivingReportViewModel request)
		{
            request.AccountDetailsId = _userManager.GetUserId(User);
			var response = _mapper.Map<ReceivingReport>(request);
			if (ModelState.IsValid) //not not
			{
				_unitOfWork.ReceivingReport.Add(response);
				await _unitOfWork.Save();
				TempData["success"] = "Receiving report successfully updated";
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
            var loggedInUser = await _unitOfWork.AccountDetails.Get(
                user => user.Id == loggedInUserId, includeProperties: "MeatEstablishment");
            var meatDealerList = await _unitOfWork.MeatDealers.GetAll(
               c => c.MeatEstablishmentId == loggedInUser.MeatEstablishmentId,
               includeProperties: "MeatEstablishment");
            var meatDealers = meatDealerList.Select(c => new
            {
                Id = c.Id,
                FullName = $"{c.FirstName} {c.LastName}"
            });
            ViewBag.MeatDealersId = new SelectList(meatDealers, "Id", "FullName");
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

			TempData["success"] = "Transaction Success";
			return RedirectToAction("Index");
		}

		// GET: ReceivingReports/Delete/5
		public async Task<IActionResult> Delete(Guid? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}

			var receivingReport = await _unitOfWork.ReceivingReport.GetAll(c => c.Id == Id);
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
            TempData["success"] = "Receiving report successfully deleted";
            return RedirectToAction(nameof(Index));
		}
	}
}

