using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Areas.Identity.Data;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;

namespace thesis.Controllers
{
	public class UsersManagementController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly thesisContext _context;

		public UsersManagementController(IUnitOfWork unitOfWork, thesisContext context)
        {
			_unitOfWork = unitOfWork;
			_context = context;
		}
        public async Task<IActionResult> Index()
		{
			var users = await _unitOfWork.UsersManangement.GetAllUsersAsync();
			return View(users);
		}

		public async Task<IActionResult> Details(string id)
		{
			if(id == null) {
				return NotFound();
			}

			var users = await _unitOfWork.UsersManangement.GetAccountDetails(id);
			
			if (users == null)
			{
				return NotFound();
			}

			return View(users);
		}

		public async Task<IActionResult> Edit(string id)
		{
			var users = await _unitOfWork.UsersManangement.GetAccountDetails(id);
			if (users == null) return View("Error");
			var accountVm = new AccountUserViewModel
			{
				firstName = users.firstName,
				lastName = users.lastName,
				middleName = users.middleName,
				contactNo = users.contactNo,
				birthdate = users.birthdate,
				sex = users.sex,
			};
			return View(accountVm);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, AccountUserViewModel accountDetails)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit account");
				return View("Edit", accountDetails);
			}

			try
			{
				if (_unitOfWork.UsersManangement.Update(accountDetails))
				{
					_unitOfWork.UsersManangement.Save();
					return RedirectToAction(nameof(Index));
				}
				else
				{
					// Handle the case when the account is not found
					return View("Error");
				}
			}
			catch (DbUpdateConcurrencyException ex)
			{
				_context.Entry(accountDetails).Reload();
				ModelState.AddModelError("", "The entity has been modified or deleted by another user.");
				return View("Edit", accountDetails);
			}
		}

		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var users = await _unitOfWork.UsersManangement.GetAccountDetails(id);

			if (users == null)
			{
				return NotFound();
			}

			return View(users);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			var users = await _unitOfWork.UsersManangement.GetAccountDetails(id);
			if (users == null)
			{
				return Problem("your user doesn't exist");
			}
			
			if (users != null)
			{
				_unitOfWork.UsersManangement.Delete(users);
			}

			_unitOfWork.UsersManangement.Save();
			return RedirectToAction(nameof(Index));
		}

		


	}
}
