using DomainLayer.Models;
using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
	public class DashboardViewModel
	{
		public TotalWeightViewModel TotalWeightModel { get; set; }
		public IEnumerable<MTVApplication> AccountDetails { get; set; }
		public FeedbackViewModel Feedbacks { get; set; }
	}
}
