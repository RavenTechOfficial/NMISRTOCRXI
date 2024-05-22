using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NMISRTOCXI.Controllers
{
	[Authorize(Policy = "RequireInspectorAdmin")]
	public class InspectorAdminUserManagementController : Controller
	{
		// GET: InspectorAdminUserManagementController
		public ActionResult Index()
		{
			return View();
		}

		// GET: InspectorAdminUserManagementController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: InspectorAdminUserManagementController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: InspectorAdminUserManagementController/Create
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

		// GET: InspectorAdminUserManagementController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: InspectorAdminUserManagementController/Edit/5
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

		// GET: InspectorAdminUserManagementController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: InspectorAdminUserManagementController/Delete/5
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
