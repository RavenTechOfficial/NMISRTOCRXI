using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;
using AutoMapper;
using SendGrid.Helpers.Mail;

namespace NMISRTOCXI.Controllers
{
	public class AntemortemController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AntemortemController> _logger;
        private readonly IMapper _mapper;

        public AntemortemController(IUnitOfWork unitOfWork, ILogger<AntemortemController> logger, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        // Edit row in Ante Table
        public async Task<IActionResult> Edit(Guid Id, int anteRowId, int conductHead, double conductWeight, int issue, int cause, string remarks, string others)
        {
            var existingAntemortem = await _unitOfWork.Antemortem.Get(c => c.Id == anteRowId && c.ReceivingReportId == Id);

            existingAntemortem.Issue = (Issue)issue;
            existingAntemortem.NoOfHeads = conductHead;
            existingAntemortem.Weight = conductWeight;
            existingAntemortem.Cause = (Cause)cause;
            existingAntemortem.Remarks = remarks;
            existingAntemortem.Other = others;

            // Save the changes to the database
            await _unitOfWork.Save();

            var enumIssue = (Issue)issue;
            var enumCause = (Cause)cause;

			var antemortem = await _unitOfWork.Antemortem
                .GetAll(c => c.ReceivingReportId == Id);
            var totalNoOfHeads = antemortem.Sum(c => c.NoOfHeads);
            var totalWeight = antemortem.Sum(c => c.Weight);

            var response = new
            {
                success = true,
                issue = enumIssue.ToString(),
                cause = enumCause.ToString(),
                head = conductHead,
                weight = conductWeight,
                remarks = remarks,
                others = others,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight

            };

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id, int anteRowId)
        {

            var entityToDelete = await _unitOfWork.Antemortem.Get(c => c.Id == anteRowId && c.ReceivingReportId == Id);
            _unitOfWork.Antemortem.Remove(entityToDelete);
            await _unitOfWork.Save();

            var antemortem = await _unitOfWork.Antemortem
                             .GetAll(c => c.ReceivingReportId == Id);

            var totalNoOfHeads = antemortem.Sum(c => c.NoOfHeads);

            var totalWeight = antemortem.Sum(c => c.Weight);

            var response = new
            {
                success = true,
                totalhead = totalNoOfHeads,
                totalweight = totalWeight,

            };
            return Json(antemortem);
        }

        [HttpGet]
        public async Task<JsonResult> GetAnteTableData(Guid Id)
        {
			var antemortem = await _unitOfWork.Antemortem
							 .GetAll(c => c.ReceivingReportId == Id);
			var data = antemortem.Select(c => new {
								 Issue = c.Issue.ToString(),
								 NoOfHeads = c.NoOfHeads,
								 Weight = c.Weight,
								 Cause = c.Cause.ToString(),
								 Other = c.Other,
								 Id = c.Id
							 });

            var totalNoOfHeads = antemortem.Sum(c => c.NoOfHeads);
            var totalWeight = antemortem.Sum(c => c.Weight);

            var result = new
            {
                Data = data,
                TotalNoOfHeads = totalNoOfHeads,
                TotalWeight = totalWeight
            };

            return Json(result);
        }
        [HttpPost]
		public async Task<IActionResult> Create(Guid Id, int conductHead, double conductWeight, int issue, int cause, string remarks, string others)
		{
            _logger.LogInformation("CreateAsync method called with parameters: Id={Id}, conductHead={conductHead}, conductWeight={conductWeight}, issue={issue}, cause={cause}", Id, conductHead, conductWeight, issue, cause);

            try
            {
                var result = new Antemortem
                {
                    ReceivingReportId = Id,
                    NoOfHeads = conductHead,
                    Weight = conductWeight,
                    Issue = (Issue)issue,
                    Cause = (Cause)cause,
                    Remarks = remarks,
                    Other = others,
                };

                _unitOfWork.Antemortem.Add(result);
                await _unitOfWork.Save();

                var antemortem = await _unitOfWork.Antemortem
                    .GetAll(c => c.ReceivingReportId == Id);

                var totalNoOfHeads = antemortem.Sum(c => c.NoOfHeads);
                var totalWeight = antemortem.Sum(c => c.Weight);

                var response = new
                {
                    success = true,
                    message = "Meat inspection report added successfully.",
                    id = result.Id,
                    issue = result.Issue.ToString(),
                    cause = result.Cause.ToString(),
                    head = result.NoOfHeads,
                    weight = result.Weight,
                    remarks = result.Remarks,
                    others = result.Other,
                    totalhead = totalNoOfHeads,
                    totalweight = totalWeight
                };

                _logger.LogInformation("CreateAsync method completed successfully.");
                return Json(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the CreateAsync method.");
                return StatusCode(500, "Internal server error");
            }
        }
		// GET: Antemortem
		public async Task<IActionResult> Index(Guid myVariable)
		{
			ViewBag.AlertMessage = TempData["AlertMessage"] as string;
			ViewBag.MyVariable = myVariable;

			var response = await _unitOfWork.Antemortem.GetAll(c => c.ReceivingReportId == myVariable, includeProperties: "ReceivingReport");
			return View("Index", response);
		}


		// GET: Antemortem/Details/5
		public async Task<IActionResult> Details(int? Id)
		{
			if (Id == null)
			{
				return NotFound();
			}

			var antemortem = await _unitOfWork.Antemortem.Get(c => c.Id == Id, includeProperties: "ReceivingReport");
			if (antemortem == null)
			{
				return NotFound();
			}

			return View(antemortem);
		}


		// GET: Antemortem/Create
		//public IActionResult Create(Guid receivingReportId)
		//{
		//	ViewData["ReceivingReportId"] = receivingReportId;


		//	var response = new CreateAntemortemViewModel();
		//	response.ReceivingReportId = receivingReportId;

		//	return View(response);
		//}


		//// POST: Antemortem/Create
		//// To protect from overposting attacks, enable the specific properties you want to bind to.
		//// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create(CreateAntemortemViewModel request)
		//{
		//	var response = _mapper.Map<Antemortem>(request);
		//	if (ModelState.IsValid)
		//	{
		//		_unitOfWork.Antemortem.Add(response);
		//		await _unitOfWork.Save();
		//		TempData["AlertMessage"] = "Transaction Success";
		//		return RedirectToAction("Index", new { myVariable = request.ReceivingReportId });
		//	}

		//	return View();
		//}
		// GET: Antemortem/Edit/5
		//public async Task<IActionResult> Edit(int? Id)
		//{
		//	if (Id == null)
		//	{
		//		return NotFound();
		//	}

		//	var antemortem = await _unitOfWork.Antemortem.Get(c => c.Id == Id);
		//	if (antemortem == null)
		//	{
		//		return NotFound();
		//	}

		//	var response = _mapper.Map<EditAntemortemViewModel>(antemortem);

		//	return View(response);
		//}

		// POST: Antemortem/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int Id, Antemortem request)
		{
			if (Id != request.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
                _unitOfWork.Antemortem.Update(request);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
			}

			return View(request);
		}

		//// GET: Antemortem/Delete/5
		//public async Task<IActionResult> Delete(int? Id)
		//{
		//	if (Id == null)
		//	{
		//		return NotFound();
		//	}

		//	var antemortem = await _unitOfWork.Antemortem.Get(c => c.Id == Id);
		//	if (antemortem == null)
		//	{
		//		return NotFound();
		//	}

		//	return View(antemortem);
		//}

		//// POST: Antemortem/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int Id)
		//{
		//	var antemortem = await _unitOfWork.Antemortem.Get(c => c.Id == Id);
		//	if (antemortem != null)
		//	{
		//		_unitOfWork.Antemortem.Remove(antemortem);
		//	}

		//	await _unitOfWork.Save();
		//	TempData["AlertMessage"] = "Transaction Success";
		//	return RedirectToAction(nameof(Index));
		//}
	}
}