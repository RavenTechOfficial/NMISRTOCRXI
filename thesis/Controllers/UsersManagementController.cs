using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text;
using thesis.Areas.Identity.Data;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;
using Microsoft.AspNetCore.Authorization;

namespace thesis.Controllers
{
	public class UsersManagementController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly thesisContext _context;
        private readonly UserManager<AccountDetails> _userManager;
        private readonly IEmailSender _emailSender;

        public UsersManagementController(
			IUnitOfWork unitOfWork, 
			thesisContext context,
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
		[Authorize(Policy = "RequireSuperAdmin")]
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
			string filename = Path.GetFileName(users.image);
			ViewBag.filename = filename;

			return View(users);
		}
		[Authorize(Policy = "RequireSuperAdmin")]
		public async Task<IActionResult> Edit(string id)
		{
			var users = await _unitOfWork.UsersManangement.GetAccountDetails(id); // AccountDetails
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
		[Authorize(Policy = "RequireSuperAdmin")]
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
			string filename = Path.GetFileName(users.image);
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
			
			if (users != null)
			{
				_unitOfWork.UsersManangement.Delete(users);
			}

			_unitOfWork.UsersManangement.Save();
			return RedirectToAction(nameof(Index));
		}

		


	}
}
