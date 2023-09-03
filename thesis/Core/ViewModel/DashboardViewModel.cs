using thesis.Areas.Identity.Data;
using thesis.Models;

namespace thesis.Core.ViewModel
{
	public class DashboardViewModel
	{
		public TotalWeightViewModel TotalWeightModel { get; set; }
		public IEnumerable<MTVApplication> AccountDetails { get; set; }
	}
}
