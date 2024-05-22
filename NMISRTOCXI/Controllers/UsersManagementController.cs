using DomainLayer.Models;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceLayer.Services.IRepositories;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NMISRTOCXI.Controllers
{
    public class UsersManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        private readonly UserManager<AccountDetails> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public UsersManagementController(
            IUnitOfWork unitOfWork,
            AppDbContext context,
            UserManager<AccountDetails> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        [Authorize(Policy = "RequireSuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var users = await _unitOfWork.AccountDetails.GetAll(includeProperties: "MeatEstablishment");
            return View(users);
        }

        [HttpGet]
        [Authorize(Policy = "RequireInspectorAdmin")]
        public async Task<IActionResult> IndexInspectorAdmin()
        {
			// Roles to filter
			var rolesToFilter = new[] { "MeatEstablishmentRepresentative", "MeatInspector" };

			// List to hold users and their roles
			var usersAndRoles = new List<AccountDetailViewModel>();

			// Loop through each role and get users in it
			foreach (var role in rolesToFilter)
			{
				var usersInRole = await _userManager.GetUsersInRoleAsync(role);
				// Add users and their roles to the list

				foreach (var user in usersInRole)
				{
                    string meatEstablishmentName = user.MeatEstablishment != null ? user.MeatEstablishment.Name : null;
                    usersAndRoles.Add(
                        new AccountDetailViewModel {
							Id = user.Id,
							firstName = user.FirstName,
							lastName = user.LastName,
							middleName = user.MiddleName,
							address = user.Address,
							email = user.Email,
							MeatEstablishmentName = meatEstablishmentName, 
                            Role = role 
                        }
                    );
				}
			}

			// Pass the users and their roles to the view
			return View(usersAndRoles);
		}

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _unitOfWork.AccountDetails.Get(c => c.Id == id);
            if (user == null)
                return NotFound();

            ViewBag.filename = Path.GetFileName(user.Image);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> MeatCheckDetails(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _unitOfWork.AccountDetails.Get(c => c.Id == id);
            if (user == null)
                return NotFound();

            ViewBag.filename = Path.GetFileName(user.Image);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _unitOfWork.AccountDetails.Get(c => c.Id == id);
            if (user == null)
                return View("Error");

            var accountVm = new AccountUserViewModel
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                middleName = user.MiddleName,
                birthdate = user.BirthDate,
                sex = user.Gender,
            };

            return View(accountVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AccountUserViewModel accountDetails)
        {
            if (!ModelState.IsValid)
                return View("Edit", accountDetails);

            try
            {
                if (_unitOfWork.UsersManangement.Update(accountDetails))
                {
                    await _unitOfWork.Save();

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

                    // Notification
                    await NotifyUserEditAsync(user, id);
                    // Notification End

                    return RedirectToAction(nameof(EditConfirmation));
                }
                else
                {
                    return View("Error");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.Entry(accountDetails).Reload();
                ModelState.AddModelError("", "The entity has been modified or deleted by another user.");
                return View("Edit", accountDetails);
            }
        }

        [HttpGet]
        public IActionResult EditConfirmation()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "RequireSuperAdmin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _unitOfWork.AccountDetails.Get(c => c.Id == id);
            if (user == null)
                return NotFound();

            ViewBag.filename = Path.GetFileName(user.Image);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _unitOfWork.AccountDetails.Get(c => c.Id == id);
            if (user == null)
                return Problem("your user doesn't exist");

            _unitOfWork.AccountDetails.Remove(user);

            await NotifyUserDeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task NotifyUserEditAsync(AccountDetails user, string editedUserId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userName = currentUser.FirstName + " " + currentUser.LastName;

            var logEntry = new LogTransaction
            {
                LogName = userName,
                LogPurpose = $"Edited the User [{editedUserId}]",
                LogDate = DateTime.Now
            };

            _context.Add(logEntry);
            await _context.SaveChangesAsync();

            TempData["success"] = $"User Edited Successfully by {userName}";
        }

        private async Task NotifyUserDeleteAsync(string deletedUserId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userName = currentUser.FirstName + " " + currentUser.LastName;

            var logEntry = new LogTransaction
            {
                LogName = userName,
                LogPurpose = $"Deleted the User [{deletedUserId}] With Role]",
                LogDate = DateTime.Now
            };

            _context.Add(logEntry);
            await _unitOfWork.Save();

            TempData["success"] = $"User Deleted Successfully by {userName}";
        }
    }
}
