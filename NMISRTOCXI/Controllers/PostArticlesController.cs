using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace NMISRTOCXI.Controllers
{
	public class PostArticlesController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public PostArticlesController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
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
						Problem("Entity set 'AppDbContext.PostArticles'  is null.");
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
				string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var user = _context.Users.FirstOrDefault(pu => pu.Id == userId);

				if (user != null)
				{
					// Construct a success message with the user's name
					var name = user.FirstName + " " + user.LastName;
					TempData["success"] = $"Article Successfully Added by {name}";


					// Add the new article to the database
					_context.Add(postArticle);

					var logEntry = new LogTransaction
					{
						LogName = name,
						LogPurpose = "Created an Article [" + postArticle.Title + "]",
						LogDate = DateTime.Now
					};
					_context.Add(logEntry);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));

				}
				else
				{
					// Handle the case where the user is not found
					TempData["error"] = "Error Found";
				}
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

					string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
					var user = _context.Users.FirstOrDefault(pu => pu.Id == userId);

					if (user != null)
					{
						// Construct a success message with the user's name
						var name = user.FirstName + " " + user.LastName;
						TempData["info"] = $"Article Successfully Edited by {name}";


						// Add the new article to the database
						_context.Update(postArticle);

						var logEntry = new LogTransaction
						{
							LogName = name,
							LogPurpose = "Edited an Article [" + postArticle.Title + "]",
							LogDate = DateTime.Now
						};
						_context.Add(logEntry);
						await _context.SaveChangesAsync();
					}
					else
					{
						// Handle the case where the user is not found
						TempData["error"] = "Error Found";
					}

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
				return Problem("Entity set 'AppDbContext.PostArticles'  is null.");
			}
			var postArticle = await _context.PostArticles.FindAsync(id);

			if (postArticle != null)
			{
				string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var user = _context.Users.FirstOrDefault(pu => pu.Id == userId);

				if (user != null)
				{
					// Construct a success message with the user's name
					var name = user.FirstName + " " + user.LastName;
					TempData["success"] = $"Article Successfully Deleted by {name}";


					// Deletes the article from the database
					_context.PostArticles.Remove(postArticle);

					var logEntry = new LogTransaction
					{
						LogName = name,
						LogPurpose = "Deleted an Article [" + postArticle.Title + "]",
						LogDate = DateTime.Now
					};
					_context.Add(logEntry);
				}
				else
				{
					// Handle the case where the user is not found
					TempData["error"] = "Error Found";
				}
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
