using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Data;
using thesis.Models;

namespace thesis.Controllers
{
    public class MTVRegistrationstatus : Controller
    {
        private readonly thesisContext _context;

        public MTVRegistrationstatus(thesisContext context)
        {
            _context = context;
        }
        [Authorize(Policy = "RequireMTVAdmin")]
        public async Task<IActionResult> IndexAsync()
        {
            var res = await _context.MTVApplications.Include(ve => ve.Vehicle).ToListAsync();
            return View(res);
        }
		[HttpPost]
		public async Task<IActionResult> ProcessApprovement(string action, int vehicleId)
		{
			// First, we need to fetch the vehicle record using vehicleId
			MTVApplication vehicle = await _context.MTVApplications.FindAsync(vehicleId);

			if (vehicle == null)
			{
				// Handle the case where the vehicle is not found
				return NotFound();
			}

			switch (action)
			{
				case "approve":
					vehicle.Status = "payment";
					break;
				case "disapprove":
					vehicle.Status = "process";
					break;
				case "payment":
					// Logic to check payment details
					// You might want to redirect to another action here 
					// or set a specific status to indicate a need for payment.
					break;
				default:
					// Handle unexpected action values
					return BadRequest();
			}

			_context.Update(vehicle);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "MTVRegistrationstatus");
		}


	}
}
