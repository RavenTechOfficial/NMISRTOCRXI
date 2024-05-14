using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;
using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
	public class ConductOfInspectionViewModel
	{
		public IEnumerable<DomainLayer.Models.ConductOfInspection> ConductOfInspections { get; set; }
		public DomainLayer.Models.ConductOfInspection SingleConductOfInspection { get; set; }
		public IEnumerable<DomainLayer.Models.Postmortem> Postmortems { get; set; }
		public DomainLayer.Models.Postmortem SinglePostmortem { get; set; }
		public DomainLayer.Models.PassedForSlaughter SinglePassedForSlaughter { get; set; }
		public DomainLayer.Models.totalNoFitForHumanConsumptions SingleTotalFit { get; set; }


		public IEnumerable<DomainLayer.Models.SummaryAndDistributionOfMIC> Summary { get; set; }
		public DomainLayer.Models.SummaryAndDistributionOfMIC SingleSummary { get; set; }


		public Issue Issue { get; set; }
		public int NoOfHeads { get; set; }
		public double Weight { get; set; }
		public Cause Cause { get; set; }

		public int MeatInspectionReportId { get; set; }

		//postmortem
		public int Id { get; set; }
		public int PassedForSlaughterId { get; set; }
		public PassedForSlaughter PassedForSlaughter { get; set; }
		public AnimalPart AnimalPart { get; set; }
		public string? Image1 { get; set; }
		public string? Image2 { get; set; }
		public string? Image3 { get; set; }

		//PassedForSlaughter
		public int ConductOfInspectionId { get; set; }
		public ConductOfInspection? ConductOfInspection { get; set; }

		//totalNoFit
		public Species Species { get; set; }
		public double DressedWeight { get; set; }
		public int PostmortemId { get; set; }
		public Postmortem? Postmortem { get; set; }

		//summary
		public int TotalNoFitForHumanConsumptionId { get; set; }
		public totalNoFitForHumanConsumptions TotalNoFitForHumanConsumption { get; set; }
		public string DestinationName { get; set; }
		public string DestinationAddress { get; set; }
		public CertificateStatus CertificateStatus { get; set; }

	}
}
