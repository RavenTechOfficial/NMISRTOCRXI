using DomainLayer.Models;
using DomainLayer.Models;
using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
	public class MtvDashboardViewModel
	{
		public IEnumerable<AccountDetails> AccountDetails { get; set; }
		public IEnumerable<checklist> Checklists { get; set; }
		public IEnumerable<Payment> Payments { get; set; }
	}
}
