using thesis.Models;

namespace thesis.Core.ViewModel
{
	public class MtvRegistrationStatusViewModel
	{
		public IEnumerable<MTVApplication> MtvApplicants { get; set; }
		public checklist checklists { get; set; }
	}
}
