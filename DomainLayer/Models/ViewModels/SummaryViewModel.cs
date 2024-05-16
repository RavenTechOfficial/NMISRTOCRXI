using DomainLayer.Enum;
using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
	public class SummaryViewModel
	{
		public IEnumerable<DomainLayer.Models.MeatInspectionSummaryAndDistributionOfMIC> Summary { get; set; }
		public DomainLayer.Models.MeatInspectionSummaryAndDistributionOfMIC SingleSummary { get; set; }


		public int Id { get; set; }
		public int TotalNoFitForHumanConsumptionId { get; set; }
		public TotalNoFitForHumanConsumptions TotalNoFitForHumanConsumption { get; set; }
		public string DestinationName { get; set; }
		public string DestinationAddress { get; set; }
		public CertificateStatus CertificateStatus { get; set; }
	}
}
