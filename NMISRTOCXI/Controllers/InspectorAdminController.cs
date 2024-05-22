using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NMISRTOCXI.Controllers
{
	[Authorize(Policy = "RequireInspectorAdmin")]
	public class InspectorAdminController : Controller
	{
		// GET: InspectorAdminController
		public ActionResult Index()
		{
			return View();
		}

		// GET: InspectorAdminController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}


		// GET: InspectorAdminController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: InspectorAdminController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: InspectorAdminController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: InspectorAdminController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: InspectorAdminController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: InspectorAdminController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
