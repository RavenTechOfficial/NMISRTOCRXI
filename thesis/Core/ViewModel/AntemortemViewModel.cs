using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.ViewModel
{
	public class ConductOfInspectionViewModel
	{
		public IEnumerable<thesis.Models.ConductOfInspection> ConductOfInspections { get; set; }
		public thesis.Models.ConductOfInspection SingleConductOfInspection { get; set; }
		public IEnumerable<thesis.Models.Postmortem> Postmortems { get; set; }
		public thesis.Models.Postmortem SinglePostmortem { get; set; }
		public thesis.Models.PassedForSlaughter SinglePassedForSlaughter { get; set; }
		public thesis.Models.totalNoFitForHumanConsumptions SingleTotalFit { get; set; }


		public IEnumerable<thesis.Models.SummaryAndDistributionOfMIC> Summary { get; set; }
		public thesis.Models.SummaryAndDistributionOfMIC SingleSummary { get; set; }


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
