using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    [Authorize(Policy = "RequireInspectorAdmin")]
    public class MeatEstablishmentsController : Controller
    {
        private readonly thesisContext _context;

        public MeatEstablishmentsController(thesisContext context)
        {
            _context = context;
        }

        // GET: MeatEstablishments
        public async Task<IActionResult> Index()
        {
            var meatEstablishments = await _context.MeatEstablishment.ToListAsync();
            return View(meatEstablishments);
        }

        // GET: MeatEstablishments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeatEstablishment == null)
            {
                return NotFound();
            }

            var meatEstablishment = await _context.MeatEstablishment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meatEstablishment == null)
            {
                return NotFound();
            }
            var viewModel = new MeatEstablishmentViewModel();
            viewModel.SingleMeatEstablishment = meatEstablishment;

            return View(viewModel);
        }

        // GET: MeatEstablishments/Create
        public IActionResult Create()
        {
            var viewModel = new MeatEstablishmentViewModel
            {
                MeatEstablishments = _context.MeatEstablishment.ToList()
            };
            return View(viewModel);
        }

        // POST: MeatEstablishments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Name,Address,LicenseToOperateNumber")] MeatEstablishment meatEstablishment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meatEstablishment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(meatEstablishment);
        }


        // GET: MeatEstablishments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meatEstablishment = await _context.MeatEstablishment.FindAsync(id);
            if (meatEstablishment == null)
            {
                return NotFound();
            }

            return View(meatEstablishment);
        }

        // POST: MeatEstablishments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Name,Address,LicenseToOperateNumber")] MeatEstablishment meatEstablishment)
        {
            if (id != meatEstablishment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meatEstablishment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeatEstablishmentExists(meatEstablishment.Id.Value))
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
            return View(meatEstablishment);
        }

        // GET: MeatEstablishments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meatEstablishment = await _context.MeatEstablishment
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meatEstablishment == null)
            {
                return NotFound();
            }

            return View(meatEstablishment);
        }

        // POST: MeatEstablishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var meatEstablishment = await _context.MeatEstablishment.FindAsync(id);

            if (meatEstablishment == null)
            {
                return NotFound();
            }

            _context.MeatEstablishment.Remove(meatEstablishment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MeatEstablishmentExists(int id)
        {
            return _context.MeatEstablishment.Any(e => e.Id == id);
        }
    }
}