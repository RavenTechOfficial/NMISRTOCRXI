using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.ViewModel
{
	public class SummaryViewModel
	{
		public IEnumerable<thesis.Models.SummaryAndDistributionOfMIC> Summary { get; set; }
		public thesis.Models.SummaryAndDistributionOfMIC SingleSummary { get; set; }


		public int Id { get; set; }
		public int TotalNoFitForHumanConsumptionId { get; set; }
		public totalNoFitForHumanConsumptions TotalNoFitForHumanConsumption { get; set; }
		public string DestinationName { get; set; }
		public string DestinationAddress { get; set; }
		public CertificateStatus CertificateStatus { get; set; }
	}
}
