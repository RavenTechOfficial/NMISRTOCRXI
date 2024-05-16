using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
    public class ConductOfInspectionViewModel
	{
		public IEnumerable<MeatInspectionAntemortem> ConductOfInspections { get; set; }
        public MeatInspectionAntemortem SingleConductOfInspection { get; set; }
		public IEnumerable<MeatInspectionPostmortem> Postmortems { get; set; }
		public MeatInspectionPostmortem SinglePostmortem { get; set; }
		public MeatInspectionPassedForSlaughter SinglePassedForSlaughter { get; set; }
		public TotalNoFitForHumanConsumptions SingleTotalFit { get; set; }


		public IEnumerable<MeatInspectionSummaryAndDistributionOfMIC> Summary { get; set; }
		public MeatInspectionSummaryAndDistributionOfMIC SingleSummary { get; set; }


		public Issue Issue { get; set; }
		public int NoOfHeads { get; set; }
		public double Weight { get; set; }
		public Cause Cause { get; set; }

		public int MeatInspectionReportId { get; set; }

		//postmortem
		public int Id { get; set; }
		public int PassedForSlaughterId { get; set; }
		public MeatInspectionPassedForSlaughter PassedForSlaughter { get; set; }
		public AnimalPart AnimalPart { get; set; }
		public string? Image1 { get; set; }
		public string? Image2 { get; set; }
		public string? Image3 { get; set; }

		//PassedForSlaughter
		public int ConductOfInspectionId { get; set; }
		public MeatInspectionAntemortem? ConductOfInspection { get; set; }

		//totalNoFit
		public Species Species { get; set; }
		public double DressedWeight { get; set; }
		public int PostmortemId { get; set; }
		public MeatInspectionPostmortem? Postmortem { get; set; }

		//summary
		public int TotalNoFitForHumanConsumptionId { get; set; }
		public TotalNoFitForHumanConsumptions TotalNoFitForHumanConsumption { get; set; }
		public string DestinationName { get; set; }
		public string DestinationAddress { get; set; }
		public CertificateStatus CertificateStatus { get; set; }

	}
}
