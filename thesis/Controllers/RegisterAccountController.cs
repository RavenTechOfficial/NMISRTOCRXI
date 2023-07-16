using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using thesis.Areas.Identity.Data;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class RegisterAccountController : Controller
    {
        private readonly UserManager<AccountDetails> _userManager;
        private readonly SignInManager<AccountDetails> _signInManager;
        private readonly thesisContext _context;

        public RegisterAccountController(UserManager<AccountDetails> userManager,
            SignInManager<AccountDetails> signInManager,
            thesisContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [Authorize(Policy = "RequireSuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }


        
    }
}
