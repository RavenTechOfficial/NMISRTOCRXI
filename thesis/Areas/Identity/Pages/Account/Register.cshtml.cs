// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using thesis.Areas.Identity.Data;
using thesis.Data;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Areas.Identity.Pages.Account
{
    
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AccountDetails> _signInManager;
        private readonly UserManager<AccountDetails> _userManager;
        private readonly IUserStore<AccountDetails> _userStore;
        private readonly IUserEmailStore<AccountDetails> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _hostEnvironment;
		private readonly thesisContext _context;

		public RegisterModel(
            UserManager<AccountDetails> userManager,
            IUserStore<AccountDetails> userStore,
            SignInManager<AccountDetails> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IWebHostEnvironment hostEnvironment,
			thesisContext context)
		{
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _hostEnvironment = hostEnvironment;
			_context = context;
		}

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			/// 
			public MeatEstablishment MeatEstablishment { get; set; }
			public int MeatEsblishmentId { get; set; }
			public Roles Roles { get; set;}

            [Required]
            [Display(Name = "FirstName")]
            public string firstName { get; set; }

            [Required]
            [Display(Name = "LastName")]
            public string lastName { get; set; }

            [Required]
            [Display(Name = "middleName")]
            public string middleName { get; set; }

            [Required]
            [Display(Name = "Address")]
            public string address { get; set; }
			[Required]
            [Display(Name = "contactNo")]
            public string contactNo { get; set; }

			[Required(ErrorMessage = "You must upload a picture")]
			public IFormFile image { get; set; }

			[Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Please enter type of sex")]
			[Display(Name = "Sex")]
			public string Sex { get; set; }

            [Required(ErrorMessage = "You need to input a birthdate")]
			[Display(Name = "Birthdate")]
			public DateTime Birthdate { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			var meatEstablishments = _context.MeatEstablishment
				.Where(me => me.Address != null)
				.ToList();
			ViewData["MeatEstablishments"] = new SelectList(meatEstablishments, "Id", "Name");
		}
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
				var user = CreateUser();

				if (Input.image != null && Input.image.Length > 0)
				{
					var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(Input.image.FileName)}";
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/uploaded", uniqueFileName);
					user.image = filePath;

					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						await Input.image.CopyToAsync(fileStream);
					}
				}

				user.firstName = Input.firstName;
                user.lastName = Input.lastName;
                user.middleName = Input.middleName;
                user.contactNo = Input.contactNo;
                user.address = Input.address;
                user.sex = Input.Sex;
                user.birthdate = Input.Birthdate;

                user.Roles = Input.Roles;
                user.MeatEstablishmentId = Input.MeatEsblishmentId;
                user.MeatEstablishment = new MeatEstablishment
                {
                    Type = Input.MeatEstablishment.Type ?? new EstablishmentType()
                };

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);
                    await _userManager.AddToRoleAsync(user, Input.Roles.ToString());
                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private AccountDetails CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AccountDetails>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AccountDetails)}'. " +
                    $"Ensure that '{nameof(AccountDetails)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<AccountDetails> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AccountDetails>)_userStore;
        }
    }
}
