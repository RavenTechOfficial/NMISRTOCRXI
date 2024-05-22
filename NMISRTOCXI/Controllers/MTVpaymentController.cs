using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Models;

namespace NMISRTOCXI.Controllers
{
	public class MTVpaymentController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public MTVpaymentController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}
		[Authorize(Policy = "RequireMtvUsers")]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(MtvPaymentViewModel mtvPaymentVM)
		{
			var imageLicenseBack = "";
			if (mtvPaymentVM.PaymentReceipt != null && mtvPaymentVM.PaymentReceipt.Length > 0)
			{
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(mtvPaymentVM.PaymentReceipt.FileName)}";
				var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/MTV", uniqueFileName);
				imageLicenseBack = filePath;

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await mtvPaymentVM.PaymentReceipt.CopyToAsync(fileStream);
				}
			}

			var latestMtv = _context.MTVApplications.OrderBy(p => p.Id).LastOrDefault();

			var mtv = new Payment
			{
				PaymentReceipt = imageLicenseBack,
				SOA = mtvPaymentVM.SOA,
				Date = mtvPaymentVM.Date,
				Email = mtvPaymentVM.Email,
				MTVApplication = latestMtv
			};

			_context.Add(mtv);
			await _context.SaveChangesAsync();
			return RedirectToAction("Create", "MTVapplication");

		}
	}
}
