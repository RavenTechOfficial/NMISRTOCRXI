using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class SummaryAndDistributionOfMICsController : Controller
    {
        private readonly thesisContext _context;

        public SummaryAndDistributionOfMICsController(thesisContext context)
        {
            _context = context;
        }

        // GET: SummaryAndDistributionOfMICs
        public async Task<IActionResult> Index()
        {
            var thesisContext = _context.SummaryAndDistributionOfMICs.Include(s => s.TotalNoFitForHumanConsumption);
            return View(await thesisContext.ToListAsync());
        }

        // GET: SummaryAndDistributionOfMICs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SummaryAndDistributionOfMICs == null)
            {
                return NotFound();
            }

            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs
                .Include(s => s.TotalNoFitForHumanConsumption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summaryAndDistributionOfMIC == null)
            {
                return NotFound();
            }

            return View(summaryAndDistributionOfMIC);
        }

        // GET: SummaryAndDistributionOfMICs/Create
        public IActionResult Create()
        {
            var viewModel = new SummaryViewModel
            {
                Summary = _context.SummaryAndDistributionOfMICs.Include(s => s.TotalNoFitForHumanConsumption).ToList(),
                // Populate any other necessary properties of the viewModel object
            };

            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id");
            return View(viewModel);
        }

        // POST: SummaryAndDistributionOfMICs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalNoFitForHumanConsumptionId,DestinationName,DestinationAddress,CertificateStatus")] SummaryAndDistributionOfMIC summaryAndDistributionOfMIC)
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] idChars = new char[10];

            for (int i = 0; i < 10; i++)
            {
                idChars[i] = characters[random.Next(characters.Length)];
            }

            string id = new string(idChars);


            var query = from mir in _context.MeatInspectionReports
                        join rr in _context.ReceivingReports on mir.ReceivingReportId equals rr.Id
                        join coi in _context.ConductOfInspections on mir.Id equals coi.MeatInspectionReportId
                        join pfs in _context.PassedForSlaughters on coi.Id equals pfs.ConductOfInspectionId
                        join pm in _context.Postmortems on pfs.Id equals pm.PassedForSlaughterId
                        join tnfhc in _context.totalNoFitForHumanConsumptions on pm.Id equals tnfhc.PostmortemId
                        join sdmics in _context.SummaryAndDistributionOfMICs on tnfhc.Id equals sdmics.TotalNoFitForHumanConsumptionId
                        select new Result
                        {
                            RecTime = rr.RecTime,
                            Species = rr.Species,
                            LiveWeight = rr.LiveWeight,
                            MeatDealer = rr.MeatDealers.FirstName + ' ' + rr.MeatDealers.LastName,
                            Issue = (Data.Enum.Issue)coi.Issue,
                            NoOfHeads = coi.NoOfHeads,
                            Weight = coi.Weight,
                            Cause = (Data.Enum.Cause)coi.Cause,
                            NoOfHeadsPassed = pfs.NoOfHeads,
                            WeightPassed = pfs.Weight,
                            AnimalPart = (Data.Enum.AnimalPart)pm.AnimalPart,
                            PostmortemCause = (Data.Enum.Cause)pm.Cause,
                            PostmortemWeight = (int)pm.Weight,
                            PostmortemNoOfHeads = (int)pm.NoOfHeads,
                            Image1 = pm.Image1,
                            Image2 = pm.Image2,
                            Image3 = pm.Image3,
                            FitforConSpecies = tnfhc.Species,
                            FitforConNoOfHeads = tnfhc.NoOfHeads,
                            DressedWeight = tnfhc.DressedWeight,
                            DestinationName = sdmics.DestinationName,
                            DestinationAddress = sdmics.DestinationAddress,
                            CertificateStatus = sdmics.CertificateStatus,
                            uid = id
                        };

            List<Result> resultList = query.ToList();

            // Order the list by Id and get the latest result
            var latestResult = resultList.OrderByDescending(p => p.Id).LastOrDefault();


            
                QrCode qr = new QrCode
                {
                    Link = "https://localhost:7116/Result/" + id,
                    uid = id
                };

                _context.Add(latestResult);
                _context.Add(qr);
                _context.SaveChanges();
            

            //_context.Results.FirstOrDefault(res => res.Id == results.Id);


            if (!ModelState.IsValid)
            {
                _context.Add(summaryAndDistributionOfMIC);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "MeatInspectionReports");
            }
            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id", summaryAndDistributionOfMIC.TotalNoFitForHumanConsumptionId);
            return View(summaryAndDistributionOfMIC);
        }

        // GET: SummaryAndDistributionOfMICs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SummaryAndDistributionOfMICs == null)
            {
                return NotFound();
            }

            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs.FindAsync(id);
            if (summaryAndDistributionOfMIC == null)
            {
                return NotFound();
            }
            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id", summaryAndDistributionOfMIC.TotalNoFitForHumanConsumptionId);
            return View(summaryAndDistributionOfMIC);
        }

        // POST: SummaryAndDistributionOfMICs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalNoFitForHumanConsumptionId,DestinationName,DestinationAddress,CertificateStatus")] SummaryAndDistributionOfMIC summaryAndDistributionOfMIC)
        {
            if (id != summaryAndDistributionOfMIC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summaryAndDistributionOfMIC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummaryAndDistributionOfMICExists(summaryAndDistributionOfMIC.Id))
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
            ViewData["TotalNoFitForHumanConsumptionId"] = new SelectList(_context.totalNoFitForHumanConsumptions, "Id", "Id", summaryAndDistributionOfMIC.TotalNoFitForHumanConsumptionId);
            return View(summaryAndDistributionOfMIC);
        }

        // GET: SummaryAndDistributionOfMICs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SummaryAndDistributionOfMICs == null)
            {
                return NotFound();
            }

            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs
                .Include(s => s.TotalNoFitForHumanConsumption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summaryAndDistributionOfMIC == null)
            {
                return NotFound();
            }

            return View(summaryAndDistributionOfMIC);
        }

        // POST: SummaryAndDistributionOfMICs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SummaryAndDistributionOfMICs == null)
            {
                return Problem("Entity set 'thesisContext.SummaryAndDistributionOfMICs'  is null.");
            }
            var summaryAndDistributionOfMIC = await _context.SummaryAndDistributionOfMICs.FindAsync(id);
            if (summaryAndDistributionOfMIC != null)
            {
                _context.SummaryAndDistributionOfMICs.Remove(summaryAndDistributionOfMIC);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummaryAndDistributionOfMICExists(int id)
        {
            return (_context.SummaryAndDistributionOfMICs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
