using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
	public class MtvRegistrationStatusViewModel
	{
		public IEnumerable<MTVApplication> MtvApplicants { get; set; }
		public checklist checklists { get; set; }
	}
}
