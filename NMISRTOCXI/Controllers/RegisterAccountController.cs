using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using InfastructureLayer.Data;

namespace NMISRTOCXI.Controllers
{
    public class RegisterAccountController : Controller
    {
        private readonly UserManager<AccountDetails> _userManager;
        private readonly SignInManager<AccountDetails> _signInManager;
        private readonly AppDbContext _context;

        public RegisterAccountController(UserManager<AccountDetails> userManager,
            SignInManager<AccountDetails> signInManager,
            AppDbContext context)
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
