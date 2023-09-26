using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class TraceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly thesisContext _context;

        public TraceController(IUnitOfWork unitOfWork, thesisContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Results != null ?
                          View(await _context.Results.ToListAsync()) :
                          Problem("Entity set 'thesisContext.Results'  is null.");
        }
        //[HttpPost]
        //public IActionResult Index(string id)
        //{
        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        var res = _context.Results.FirstOrDefault(p => p.uid == id);
        //        if (res != null)
        //        {
        //            return RedirectToAction("Result", new { uid = res.uid });
        //        }
        //    }
        //    return View();
        //}
        public async Task<IActionResult> Result(string? id)
        
        {

            if (id == null || _context.Results == null)
            {
                return NotFound();
            }

            var result = await _context.Results
                .FirstOrDefaultAsync(m => m.uid == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }
        [HttpPost]
        public IActionResult SubmitRating([FromBody] FeedbackResultViewModel feedVM)

        {

            var result = new Feedback();

            switch (feedVM.NumberOfStarsClicked)
            {
                case 1:
                    result.HighlyDissatisfied += 1;
                    break;
                case 2:
                    result.Dissatisfied += 1;
                    break;
                case 3:
                    result.Neutral += 1;
                    break;
                case 4:
                    result.Satisfied += 1;
                    break;
                case 5:
                    result.HighlySatisfied += 1;
                    break;
            }

            _context.Add(result);
            _context.SaveChanges();

            return RedirectToAction("Result", "Trace");
        }
    }
}
