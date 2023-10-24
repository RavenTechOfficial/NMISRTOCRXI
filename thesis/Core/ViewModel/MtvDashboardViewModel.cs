using thesis.Areas.Identity.Data;
using thesis.Models;

namespace thesis.Core.ViewModel
{
	public class MtvDashboardViewModel
	{
		public IEnumerable<AccountDetails> AccountDetails { get; set; }
		public IEnumerable<checklist> Checklists { get; set; }
		public IEnumerable<Payment> Payments { get; set; }
	}
}
