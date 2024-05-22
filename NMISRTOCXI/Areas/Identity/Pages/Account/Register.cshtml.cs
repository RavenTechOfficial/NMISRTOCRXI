
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using System.Data;

namespace NMISRTOCXI.Areas.Identity.Pages.Account
{

    public class RegisterModel : PageModel
	{
		private readonly SignInManager<AccountDetails> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AccountDetails> _userManager;
		private readonly IUserStore<AccountDetails> _userStore;
		private readonly IUserEmailStore<AccountDetails> _emailStore;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly AppDbContext _context;

		public RegisterModel(
			UserManager<AccountDetails> userManager,
			IUserStore<AccountDetails> userStore,
			SignInManager<AccountDetails> signInManager,
			RoleManager<IdentityRole> roleManager,
			ILogger<RegisterModel> logger,
			IEmailSender emailSender,
			IWebHostEnvironment hostEnvironment,
			AppDbContext context)
		{
			_userManager = userManager;
			_userStore = userStore;
			_emailStore = GetEmailStore();
			_signInManager = signInManager;
            _roleManager = roleManager;
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
			public Guid MeatEsblishmentId { get; set; }
			public Roles Roles { get; set; }

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
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/profile", uniqueFileName);
                    user.Image = filePath;

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Input.image.CopyToAsync(fileStream);
                    }
                }

                user.FirstName = Input.firstName;
                user.LastName = Input.lastName;
                user.MiddleName = Input.middleName;
                user.Address = Input.address;
                user.Gender = Input.Sex;
                user.BirthDate = Input.Birthdate;
                user.MeatEstablishmentId = Input.MeatEsblishmentId;

				var result = await _roleManager.RoleExistsAsync(Input.Roles.ToString());
                if (result)
                {
                    switch (Input.Roles)
                    {
                        case Roles.SUPERADMIN:
                        case Roles.MTVADMIN:
                        case Roles.INSPECTORADMIN:
                        case Roles.MTVUSERS:
                        case Roles.MTVINSPECTOR:
                            user.MeatEstablishment = new MeatEstablishment
                            {
                                Type = Input.MeatEstablishment.Type ?? new EstablishmentType()
                            };
                            break;
                        default:
                            break;
                    }

                    await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                    await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                    var createResult = await _userManager.CreateAsync(user, Input.Password);

                    if (createResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, Input.Roles.ToString());
                        _logger.LogInformation("User created a new account with password.");
						//var userId = await _userManager.GetUserIdAsync(user);
						//var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						//code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
						//var callbackUrl = Url.Page(
						//    "/Account/ConfirmEmail",
						//    pageHandler: null,
						//    values: new { area = "Identity", userId, code },
						//    protocol: Request.Scheme);
						//await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
						//    $"Greetings from NMIS RTOC R11! Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

						//return RedirectToPage("RegisterConfirmation", new { userId, code });
						return RedirectToPage("RegistrationSuccessful");
                    }

                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
				else
				{
					ModelState.AddModelError(string.Empty, "Error reading users");
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
