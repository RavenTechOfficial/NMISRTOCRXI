using Microsoft.AspNetCore.Mvc;
using InfastructureLayer.Data;

namespace NMISRTOCXI.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly AppDbContext _context;

        public ArticlesController(AppDbContext context)
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
