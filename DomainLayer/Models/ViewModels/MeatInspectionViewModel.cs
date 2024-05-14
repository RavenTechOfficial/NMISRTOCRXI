using DomainLayer.Enum;
using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
    public class MeatInspectionViewModel
    {

        public List<Antemortem> AntemortemInspectionData { get; set; }
        public List<Postmortem> PostmortemInspectionData { get; set; }
        public int MeatInspectionViewModelId { get; set; }
        public int InspectionCount { get; set; }
        public int ConductCount { get; set; }
        public int PostmortemCount { get; set; }
        public DateTime DateInspected { get; set; }
        //Receiving Report
        public int ReceivingId { get; set; }
        public int? MeatEstablishmentId { get; set; }
        public DateTime RecTime { get; set; }
        public Species? Species { get; set; }
        public double? LiveWeight { get; set; }
        public string MeatDealer { get; set; }
        public int ReceivingNoOfHeads { get; set; }

        //Conduct of Inspection
        public int MeatInspectionReportId { get; set; }
        public Issue Issue { get; set; }
        public int NoOfHeads { get; set; }
        public double Weight { get; set; }
        public Cause Cause { get; set; }

        //Passed for Slaughter
        public int AntemortemId { get; set; }
        public int NoOfHeadsPassed { get; set; }
        public double WeightPassed { get; set; }

        //Postmortem
        public int PassedId { get; set; } //huh
        public int Passed { get; set; }
        public int PostmortemId { get; set; }
        public AnimalPart? AnimalPart { get; set; }
        public double PostmortemWeight { get; set; }
        public string? PostmortemCause { get; set; }
        public int PostmortemCarcassHead { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }

        //Fit for Human Consumption
        public int FitId { get; set; }
        public double DressedWeight { get; set; }
        public int TotalNoOfHeads { get; set; }

        //Summary of MIC
        public string? DestinationName { get; set; }
        public string? DestinationAddress { get; set; }
        //public CertificateStatus? CertificateStatus { get; set; }
        public int MICIssued { get; set; }
        public int MICCancelled { get; set; }
    }
}
