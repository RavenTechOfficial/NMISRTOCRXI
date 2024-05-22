using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfastructureLayer.Data;
using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;
using SendGrid.Helpers.Mail;
using DomainLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Enum;

namespace NMISRTOCXI.Controllers
{
	public class TotalNoFitForHumanConsumptionsController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TotalNoFitForHumanConsumptionsController(IUnitOfWork unitOfWork,
            IMapper mapper)
		{
			_unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int totalHead, double totalWeight,double ofals, Guid Id)
        {
            var fitForHuman = await _unitOfWork.TotalNoFitForHumanConsumption.Get(c => c.ReceivingReportId == Id);

            if(fitForHuman == null)
            {
                fitForHuman = new TotalNoFitForHumanConsumptions
                {
                    ReceivingReportId = Id,
                    NoOfHeads = totalHead,
                    DressedWeight = totalWeight,
                    OFALS = ofals,
                };

                _unitOfWork.TotalNoFitForHumanConsumption.Add(fitForHuman);
            }
            else
            {
                fitForHuman.NoOfHeads = totalHead;
                fitForHuman.DressedWeight = totalWeight;
                fitForHuman.OFALS = ofals;
                _unitOfWork.TotalNoFitForHumanConsumption.Update(fitForHuman);
            }
            var receivingReport = await _unitOfWork.ReceivingReport.Get(c => c.Id == Id);

            if (receivingReport != null)
            {
                receivingReport.InspectionStatus = InspectionStatus.Frozen;
                _unitOfWork.ReceivingReport.Update(receivingReport);
            }

            await _unitOfWork.Save();

            var response = _mapper.Map<ReceivingReportViewModel>(receivingReport);

            if(response == null) {
                return Json(new { redirectUrl = Url.Action("Inspect", new { Id = Id }) });
            }

            return Json(new { redirectUrl = Url.Action("Index", response) });
        }
        //		// GET: TotalNoFitForHumanConsumptions
        //		public async Task<IActionResult> Index()
        //		{
        //			var IUnitOfWork = _unitOfWork.TotalNoFitForHumanConsumptions.Include(t => t.Postmortem);
        //			return View(await IUnitOfWork.ToListAsync());
        //		}

        //		// GET: TotalNoFitForHumanConsumptions/Details/5
        //		public async Task<IActionResult> Details(int? id)
        //		{
        //			if (id == null || _unitOfWork.TotalNoFitForHumanConsumptions == null)
        //			{
        //				return NotFound();
        //			}

        //			var TotalNoFitForHumanConsumptions = await _unitOfWork.TotalNoFitForHumanConsumptions
        //				.Include(t => t.Postmortem)
        //				.FirstOrDefaultAsync(m => m.Id == id);
        //			if (TotalNoFitForHumanConsumptions == null)
        //			{
        //				return NotFound();
        //			}

        //			return View(TotalNoFitForHumanConsumptions);
        //		}

        //		// GET: TotalNoFitForHumanConsumptions/Create
        //		public IActionResult Create()
        //		{
        //			int? passedForSlaughterId = TempData["PassedForSlaughterId"] as int?;
        //			int mostRecentId = (int)passedForSlaughterId;

        //			// Check if the specific PassedForSlaughterId has multiple inputs
        //			var multipleInputs = _unitOfWork.Postmortems
        //				.Where(pm => pm.PassedForSlaughterId == mostRecentId)
        //				.GroupBy(pm => pm.PassedForSlaughterId)
        //				.Select(group => new { PassedForSlaughterId = group.Key, TotalPostWeight = group.Sum(pm => pm.Weight), TotalPostNoOfHeads = group.Sum(pm => pm.NoOfHeads) })
        //				.FirstOrDefault();

        //			if (multipleInputs == null)
        //			{
        //				// Handle the case when there are no multiple inputs
        //				// You might want to show an error message or take other actions
        //			}
        //			else
        //			{
        //				double totalPostWeight = multipleInputs.TotalPostWeight; //double or float
        //				int totalPostNoOfHeads = multipleInputs.TotalPostNoOfHeads;

        //				// Execute the provided SQL queries using LINQ to calculate the differences
        //				var passedForSlaughterData = _unitOfWork.PassedForSlaughters
        //					.Where(pfs => pfs.Id == mostRecentId)
        //					.Select(pfs => new
        //					{
        //						InspectionWeight = pfs.Weight,
        //						InspectionNoOfHeads = pfs.NoOfHeads,
        //						PostWeight = totalPostWeight,
        //						PostNoOfHeads = totalPostNoOfHeads,
        //						WeightPassed = pfs.Weight - totalPostWeight,
        //						NoOfHeadsPassed = pfs.NoOfHeads - totalPostNoOfHeads
        //					})
        //					.FirstOrDefault();

        //				if (passedForSlaughterData == null)
        //				{
        //					// Handle the case when data is not found
        //					// You might want to show an error message or take other actions
        //				}
        //				else
        //				{
        //					// Pass the calculated data to the view
        //					ViewData["WeightPassed"] = passedForSlaughterData.WeightPassed;
        //					ViewData["NoOfHeadsPassed"] = passedForSlaughterData.NoOfHeadsPassed;

        //				}
        //			}
        //			//ViewData["PostmortemId"] = new SelectList(_unitOfWork.Postmortems, "Id", "Id");
        //			//return View();
        //			int latestId = _unitOfWork.Postmortems.OrderByDescending(p => p.Id).FirstOrDefault()?.Id ?? 0;
        //			ViewData["PostmortemId"] = new SelectList(_unitOfWork.Postmortems, "Id", "Id", latestId);
        //			return View();
        //		}

        //		// POST: TotalNoFitForHumanConsumptions/Create
        //		// To protect from overposting attacks, enable the specific properties you want to bind to.
        //		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //		[HttpPost]
        //		[ValidateAntiForgeryToken]
        //		public async Task<IActionResult> Create([Bind("Id,Species,NoOfHeads,DressedWeight,PostmortemId")] TotalNoFitForHumanConsumptions TotalNoFitForHumanConsumptions)
        //		{
        //			if (ModelState.IsValid)
        //			{
        //				_unitOfWork.Add(TotalNoFitForHumanConsumptions);
        //				await _unitOfWork.SaveChangesAsync();
        //				//   return RedirectToAction(nameof(Index));
        //				return RedirectToAction("Create", "SummaryAndDistributionOfMICs");
        //			}
        //			ViewData["PostmortemId"] = new SelectList(_unitOfWork.Postmortems, "Id", "Id", TotalNoFitForHumanConsumptions.PostmortemId);
        //			return View();
        //		}

        //		// GET: TotalNoFitForHumanConsumptions/Edit/5
        //		public async Task<IActionResult> Edit(int? id)
        //		{
        //			if (id == null || _unitOfWork.TotalNoFitForHumanConsumptions == null)
        //			{
        //				return NotFound();
        //			}

        //			var TotalNoFitForHumanConsumptions = await _unitOfWork.TotalNoFitForHumanConsumptions.FindAsync(id);
        //			if (TotalNoFitForHumanConsumptions == null)
        //			{
        //				return NotFound();
        //			}
        //			ViewData["PostmortemId"] = new SelectList(_unitOfWork.Postmortems, "Id", "Id", TotalNoFitForHumanConsumptions.PostmortemId);
        //			return View(TotalNoFitForHumanConsumptions);
        //		}

        //		// POST: TotalNoFitForHumanConsumptions/Edit/5
        //		// To protect from overposting attacks, enable the specific properties you want to bind to.
        //		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //		[HttpPost]
        //		[ValidateAntiForgeryToken]
        //		public async Task<IActionResult> Edit(int id, [Bind("Id,Species,NoOfHeads,DressedWeight,PostmortemId")] TotalNoFitForHumanConsumptions TotalNoFitForHumanConsumptions)
        //		{
        //			if (id != TotalNoFitForHumanConsumptions.Id)
        //			{
        //				return NotFound();
        //			}

        //			if (ModelState.IsValid)
        //			{
        //				try
        //				{
        //					_unitOfWork.Update(TotalNoFitForHumanConsumptions);
        //					await _unitOfWork.SaveChangesAsync();
        //				}
        //				catch (DbUpdateConcurrencyException)
        //				{
        //					if (!TotalNoFitForHumanConsumptionsExists(TotalNoFitForHumanConsumptions.Id))
        //					{
        //						return NotFound();
        //					}
        //					else
        //					{
        //						throw;
        //					}
        //				}
        //				return RedirectToAction(nameof(Index));
        //			}
        //			ViewData["PostmortemId"] = new SelectList(_unitOfWork.Postmortems, "Id", "Id", TotalNoFitForHumanConsumptions.PostmortemId);
        //			return View(TotalNoFitForHumanConsumptions);
        //		}

        //		// GET: TotalNoFitForHumanConsumptions/Delete/5
        //		public async Task<IActionResult> Delete(int? id)
        //		{
        //			if (id == null || _unitOfWork.TotalNoFitForHumanConsumptions == null)
        //			{
        //				return NotFound();
        //			}

        //			var TotalNoFitForHumanConsumptions = await _unitOfWork.TotalNoFitForHumanConsumptions
        //				.Include(t => t.Postmortem)
        //				.FirstOrDefaultAsync(m => m.Id == id);
        //			if (TotalNoFitForHumanConsumptions == null)
        //			{
        //				return NotFound();
        //			}

        //			return View(TotalNoFitForHumanConsumptions);
        //		}

        //		// POST: TotalNoFitForHumanConsumptions/Delete/5
        //		[HttpPost, ActionName("Delete")]
        //		[ValidateAntiForgeryToken]
        //		public async Task<IActionResult> DeleteConfirmed(int id)
        //		{
        //			if (_unitOfWork.TotalNoFitForHumanConsumptions == null)
        //			{
        //				return Problem("Entity set 'IUnitOfWork.TotalNoFitForHumanConsumptions'  is null.");
        //			}
        //			var TotalNoFitForHumanConsumptions = await _unitOfWork.TotalNoFitForHumanConsumptions.FindAsync(id);
        //			if (TotalNoFitForHumanConsumptions != null)
        //			{
        //				_unitOfWork.TotalNoFitForHumanConsumptions.Remove(TotalNoFitForHumanConsumptions);
        //			}

        //			await _unitOfWork.SaveChangesAsync();
        //			return RedirectToAction(nameof(Index));
        //		}

        //		private bool TotalNoFitForHumanConsumptionsExists(int id)
        //		{
        //			return (_unitOfWork.TotalNoFitForHumanConsumptions?.Any(e => e.Id == id)).GetValueOrDefault();
        //		}
    }
}
