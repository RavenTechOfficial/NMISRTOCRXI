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

namespace thesis.Controllers
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
        public async Task<IActionResult> IndexInspectorAdmin()
        {
            var userList = await GetUserDataAsync();
            return View(userList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _unitOfWork.AccountDetails.Get(c => c.Id == id);
            if (user == null)
                return NotFound();

            ViewBag.filename = Path.GetFileName(user.image);
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

            ViewBag.filename = Path.GetFileName(user.image);
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
                firstName = user.firstName,
                lastName = user.lastName,
                middleName = user.middleName,
                contactNo = user.contactNo,
                birthdate = user.birthdate,
                sex = user.sex,
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

            ViewBag.filename = Path.GetFileName(user.image);
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

        private async Task<List<UserManagementInspectorAdminViewModel>> GetUserDataAsync()
        {
            var rolesToFilter = new[] { "MeatEstablishmentRepresentative", "MeatInspector" };

            var usersInRoles = new List<AccountDetails>();
            foreach (var role in rolesToFilter)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role);
                usersInRoles.AddRange(usersInRole);
            }

            var distinctUserIds = usersInRoles.Select(u => u.Id).Distinct().ToList();

            var users = await _unitOfWork.AccountDetails.GetAll(c => distinctUserIds.Contains(c.Id), includeProperties: "MeatEstablishment");

            var userList = await Task.WhenAll(users.Select(async user =>
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault(r => rolesToFilter.Contains(r));
                return new UserManagementInspectorAdminViewModel
                {
                    Id = user.Id,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    middleName = user.middleName,
                    address = user.address,
                    contactNo = user.contactNo,
                    email = user.Email,
                    Role = roleName,
                    MeatEstablishmentId = user.MeatEstablishmentId,
                    MeatEstablishmentName = user.MeatEstablishment.Name
                };
            }));

            return userList.ToList();
        }

        private async Task NotifyUserEditAsync(AccountDetails user, string editedUserId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userName = currentUser.firstName + " " + currentUser.lastName;

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
            var userName = currentUser.firstName + " " + currentUser.lastName;

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
