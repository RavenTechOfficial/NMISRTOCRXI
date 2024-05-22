using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace NMISRTOCXI.Controllers
{
	public class MTVInspectorRegistrationStatusController : Controller
	{
		private readonly AppDbContext _context;

        public MTVInspectorRegistrationStatusController(AppDbContext context)
        {
			_context = context;
		}
		[Authorize(Policy = "RequireMtvInspector")]
		public async Task<IActionResult> IndexAsync()
		{
			var mtvApplications = await _context.MTVApplications.Include(ve => ve.Vehicle).ToListAsync();

			var mtvRegistrationViewModel = new MtvRegistrationStatusViewModel
			{
				MtvApplicants = mtvApplications,
				checklists = new CheckList()
			};


			return View(mtvRegistrationViewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProcessApprovement(string action, int vehicleId, MtvRegistrationStatusViewModel checks)
		{

			MTVApplication vehicle = await _context.MTVApplications.FindAsync(vehicleId);

			var mtvApplications = await _context.MTVApplications.Include(ve => ve.Vehicle).ToListAsync();



			if (vehicle == null)
			{
				return NotFound();
			}

			switch (action)
			{
				case "approve":
					vehicle.Status = "payment";
					break;
				case "disapprove":
					vehicle.Status = "process";
					break;
				default:
					return BadRequest();
			}

			CheckList existingChecklist = await _context.CheckLists
				.FirstOrDefaultAsync(c => c.plateno == checks.checklists.plateno);

			var checklists = new CheckList
			{
				operatorname = checks.checklists.operatorname,
				estserved = checks.checklists.estserved,
				plateno = checks.checklists.plateno,
				inspectorname = checks.checklists.inspectorname,
				inspectdate = checks.checklists.inspectdate,
				inspecttime = checks.checklists.inspecttime,
				status = vehicle.Status
			};

			if (existingChecklist == null)
			{
				_context.Add(checklists);
			}
			else
			{
				existingChecklist.inspectorname = checks.checklists.inspectorname;
				existingChecklist.inspectdate = checks.checklists.inspectdate;
				existingChecklist.inspecttime = checks.checklists.inspecttime;
				existingChecklist.status = vehicle.Status;
				_context.Update(existingChecklist);
			}

			_context.Update(vehicle);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "MTVRegistrationstatus");
		}
		[Authorize(Policy = "RequireMtvInspector")]
		public async Task<IActionResult> PaymentForm()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PaymentForm(int vehicleId)
		{

			Payment payment = _context.Payments
				.Include(p => p.MTVApplication)
				.Include(p => p.MTVApplication.Vehicle)
				.Where(p => p.MTVApplication.Id == vehicleId)
				.FirstOrDefault();

			var payWplate = new PaymentwPlateNoViewModel
			{
				PaymentReceipt = payment.PaymentReceipt,
				Date = payment.Date,
				Email = payment.Email,
				SOA = payment.SOA,
				MTVApplication = payment.MTVApplication,
				PlateNo = payment.MTVApplication.Vehicle.PlateNo
			};

			string filename = Path.GetFileName(payment.PaymentReceipt);
			ViewBag.filename = filename;

			return View(payWplate);


		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CompleteApprovement(string action, PaymentwPlateNoViewModel payment)
		{

			MTVApplication vehicle = await _context.MTVApplications.FindAsync(payment.MTVApplication.Id);
			CheckList checks = _context.CheckLists
				.Where(p => p.plateno == payment.PlateNo)
				.FirstOrDefault();

			if (vehicle == null)
			{
				return NotFound();
			}

			switch (action)
			{
				case "approve":
					vehicle.Status = "completed";
					checks.status = "completed";
					break;
				case "disapprove":
					vehicle.Status = "payment";
					checks.status = "payment";
					break;
				default:
					return BadRequest();
			}




			_context.Update(vehicle);
			_context.Update(checks);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "MTVRegistrationstatus");

		}
	}
}
