using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using InfastructureLayer.Data;

namespace thesis.Controllers
{
    public class RegisterAccountController : Controller
    {
        private readonly UserManager<AccountDetail> _userManager;
        private readonly SignInManager<AccountDetail> _signInManager;
        private readonly AppDbContext _context;

        public RegisterAccountController(UserManager<AccountDetail> userManager,
            SignInManager<AccountDetail> signInManager,
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
