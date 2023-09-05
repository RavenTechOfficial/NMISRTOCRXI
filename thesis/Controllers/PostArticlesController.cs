using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class PostArticlesController : Controller
    {
        private readonly thesisContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public PostArticlesController(thesisContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
			_webHostEnvironment = webHostEnvironment;
		}

		// GET: PostArticles
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Index()
        {
              return _context.PostArticles != null ? 
                          View(await _context.PostArticles.ToListAsync()) :
                          Problem("Entity set 'thesisContext.PostArticles'  is null.");
        }

		// GET: PostArticles/Details/5
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostArticles == null)
            {
                return NotFound();
            }

            var postArticle = await _context.PostArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postArticle == null)
            {
                return NotFound();
            }

            return View(postArticle);
        }

		// GET: PostArticles/Create
		[Authorize(Policy = "RequireSuperAdmin")]
		public IActionResult Create()
        {
            return View();
        }

        // POST: PostArticles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostArticleViewModel postArticleVM)
        {
            var imageArticle = "";
            if (postArticleVM.Image != null && postArticleVM.Image.Length > 0)
            {
                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(postArticleVM.Image.FileName)}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/Articles", uniqueFileName);
                imageArticle = uniqueFileName;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await postArticleVM.Image.CopyToAsync(fileStream);
                }
            }

            var postArticle = new PostArticle
            {
                Author = postArticleVM.Author,
                Label = postArticleVM.Label,
                Title = postArticleVM.Title,
                Description = postArticleVM.Description,
                Image = imageArticle,
				Introduction = postArticleVM.Introduction,
                Body = postArticleVM.Body,
                Conclusion = postArticleVM.Conclusion,
                References = postArticleVM.References,
                Date = postArticleVM.Date,
            };

			if (ModelState.IsValid)
            {
                _context.Add(postArticle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postArticle);
        }

		// GET: PostArticles/Edit/5
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostArticles == null)
            {
                return NotFound();
            }

            var postArticle = await _context.PostArticles.FindAsync(id);
            if (postArticle == null)
            {
                return NotFound();
            }
            return View(postArticle);
        }

        // POST: PostArticles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,Label,Title,Description,Image,Introduction,Body,Conclusion,References,Date")] PostArticle postArticle)
        {
            if (id != postArticle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postArticle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostArticleExists(postArticle.Id))
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
            return View(postArticle);
        }

		// GET: PostArticles/Delete/5
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostArticles == null)
            {
                return NotFound();
            }

            var postArticle = await _context.PostArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postArticle == null)
            {
                return NotFound();
            }

            return View(postArticle);
        }

        // POST: PostArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostArticles == null)
            {
                return Problem("Entity set 'thesisContext.PostArticles'  is null.");
            }
            var postArticle = await _context.PostArticles.FindAsync(id);
            if (postArticle != null)
            {
                _context.PostArticles.Remove(postArticle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostArticleExists(int id)
        {
          return (_context.PostArticles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
