using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using DomainLayer.Models;

namespace thesis.Controllers
{
    public class UsersManagementController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly AppDbContext _context;
		private readonly UserManager<AccountDetails> _userManager;
		private readonly IEmailSender _emailSender;

		public UsersManagementController(
			IUnitOfWork unitOfWork,
			AppDbContext context,
			UserManager<AccountDetails> userManager,
            IEmailSender emailSender)
		{
			_unitOfWork = unitOfWork;
			_context = context;
			_userManager = userManager;
			_emailSender = emailSender;
		}
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Index()
		{

			var users = await _unitOfWork.UsersManangement.GetAllUsersAsync();
			return View(users);
		}
		public List<UserManagementInspectorAdminViewModel> GetUserData()
		{
			var userList = _context.Users
				.Join(
					_context.MeatEstablishment,
					user => user.MeatEstablishmentId,
					meatEstablishment => meatEstablishment.Id,
					(user, meatEstablishment) => new UserManagementInspectorAdminViewModel
					{
						Id = user.Id,
						firstName = user.firstName,
						lastName = user.LastName,
						middleName = user.MiddleName,
						address = user.address,
						contactNo = user.contactNo,
						email = user.Email,
						Roles = user.Roles, // Assuming Roles is a property in your User entity
						MeatEstablishmentId = user.MeatEstablishmentId,
						MeatEstablishmentName = meatEstablishment.Name
					})
				.Where(user => user.Roles == Roles.MEATESTABLISHMENTREPRESENTATIVE || user.Roles == Roles.MEATINSPECTOR)
				.ToList();

			return userList;

		}

		public async Task<IActionResult> IndexInspectorAdmin()
		{
			var userList = GetUserData();

			return View(userList);
		}
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Details(string id)
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
			string filename = Path.GetFileName(users.ImageUrl);
			ViewBag.filename = filename;

			return View(users);
		}
		public async Task<IActionResult> MeatCheckDetails(string id)
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
			string filename = Path.GetFileName(users.ImageUrl);
			ViewBag.filename = filename;

			return View(users);
		}

		public async Task<IActionResult> MeatCheckEdit(string id)
		{
			var users = await _unitOfWork.UsersManangement.GetAccountDetails(id); // AccountDetails
			if (users == null) return View("Error");
			var accountVm = new AccountUserViewModel
			{
				firstName = users.firstName,
				lastName = users.LastName,
				middleName = users.MiddleName,
				contactNo = users.contactNo,
				birthdate = users.BirthDate,
				sex = users.Gender,
			};
			return View(accountVm);
		}
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Edit(string id)
		{
			var users = await _unitOfWork.UsersManangement.GetAccountDetails(id); // AccountDetails
			if (users == null) return View("Error");
			var accountVm = new AccountUserViewModel
			{
				firstName = users.firstName,
				lastName = users.LastName,
				middleName = users.MiddleName,
				contactNo = users.contactNo,
				birthdate = users.BirthDate,
				sex = users.Gender,
			};
			return View(accountVm);
		}

		[HttpPost]
		public async Task<IActionResult> MeatCheckEdit(string id, AccountUserViewModel accountDetails)
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

					// Send confirmation email
					var user = await _userManager.GetUserAsync(User);
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/EditConfirmation",
						pageHandler: null,
						values: new { area = "Identity", userId = user.Id, code = code },
						protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
						$"Please confirm your updated account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					return RedirectToAction(nameof(EditConfirmation));
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

					// Send confirmation email
					var user = await _userManager.GetUserAsync(User);
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/EditConfirmation",
						pageHandler: null,
						values: new { area = "Identity", userId = user.Id, code = code },
						protocol: Request.Scheme);

					await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
						$"Please confirm your updated account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					//Notification

					string USER_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
					var USER_ = _context.Users.FirstOrDefault(pu => pu.Id == USER_ID);
					var editedUser = await _unitOfWork.UsersManangement.GetAccountDetails(id);

					if (USER_ != null)
					{
						// Construct a success message with the user's name
						var name = USER_.firstName + " " + USER_.LastName;
						TempData["info"] = $"User Edited Successfully by {name}";

						var logEntry = new LogTransaction
						{
							LogName = name,
							LogPurpose = $"Edited the User [{editedUser}]",
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

					// Notification End


					return RedirectToAction(nameof(EditConfirmation));


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
		//[Authorize(Policy = "RequireSuperAdmin")]
		public IActionResult EditConfirmation()
		{
			return View();
		}
		[Authorize(Policy = "RequireSuperAdmin")]
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
			string filename = Path.GetFileName(users.ImageUrl);
			ViewBag.filename = filename;

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

			string USER_ID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var USER_ = _context.Users.FirstOrDefault(pu => pu.Id == USER_ID);
			var deletedUserEmail = users.Email;

			if (deletedUserEmail != USER_.Email)
			{
				_unitOfWork.UsersManangement.Delete(users);

				if (USER_ != null)
				{
					var name = USER_.firstName + " " + USER_.LastName;
					TempData["success"] = $"User Deleted Successfully by {name}";

					var logEntry = new LogTransaction
					{
						LogName = name,
						LogPurpose = $"Deleted the User [{deletedUserEmail}] Role [{users.Roles}]",
						LogDate = DateTime.Now
					};
					_context.Add(logEntry);
					await _context.SaveChangesAsync();

					_unitOfWork.UsersManangement.Save();
				}
				else
				{
					TempData["error"] = "Error Found";
				}
			}
			else
			{
				TempData["error"] = "You cannot delete your own account";
			}

			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> MeatCheckDelete(string id)
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
			string filename = Path.GetFileName(users.ImageUrl);
			ViewBag.filename = filename;

			return View(users);
		}

		[HttpPost, ActionName("MeatCheckDelete")]
		public async Task<IActionResult> MeatCheckDeleteConfirmed(string id)
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
			return RedirectToAction(nameof(IndexInspectorAdmin));
		}



	}
}
