using Microsoft.AspNetCore.Mvc;
using thesis.Data;

namespace thesis.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly thesisContext _context;

        public ArticlesController(thesisContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var res = _context.PostArticles.OrderByDescending(p => p.Id).ToList();
            return View(res);
        }
        public IActionResult Details(int Id)
        {
            var res = _context.PostArticles.FirstOrDefault(p => p.Id == Id);
            return View(res);
        }
    }
}
