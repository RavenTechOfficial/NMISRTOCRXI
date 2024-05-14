using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
    public class MeatInspectionReportViewModel
    {
        public List<MeatInspectionReport> MeatInspectionData { get; set; }
        public List<ReceivingReport> ReceivingReportData { get; set; }

        public DomainLayer.Models.MeatInspectionReport MeatInspectionReports { get; set; }

        public string UID { get; set; }

        public int Id { get; set; }
        public int MeatInspectionReportId { get; set; }
        public DateTime DateReceived { get; set; }
        public Species? Specie { get; set; }
        public string MeatDealer { get; set; }
        public string MeatEstablishment { get; set; }
        public DateTime DateInspected { get; set; }
        public string MeatInspector { get; set; }
        public string VerifiedBy { get; set; }

        public DateTime RepDate { get; set; }
        public int ReceivingReportId { get; set; }
        public int PassedId { get; set; }
        public int AntemortemId { get; set; }
        public int PostmortemId { get; set; }
        public int TotalNoId { get; set; }
        public int SummaryId { get; set; }
        public ReceivingReport? ReceivingReport { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? LicenseToOperateNumber { get; set; }
        public string? AccountDetailsId { get; set; }

        public int? NoOfHeads { get; set; }
        public string? Origin { get; set; }
        public AnimalPart? AnimalPart { get; set; }
        public Issue? Issue { get; set; }
        public Cause? Cause { get; set; }
        public double? Weight { get; set; }
        public int? piNoOfHeads { get; set; }
        public Cause? piCause { get; set; }
        public double? piWeight { get; set; }
        public int? tnNoOfHeads { get; set; }
        public double? tnDressedWeight { get; set; }
        public int? MICIssued { get; set; }
        public int? MICCancelled { get; set; }


        public string? MeatEstablishmentAddress { get; set; }
        public string? DestinationName { get; set; }
        public string? DestinationAddress { get; set; }
        public CertificateStatus? CertificateStatus { get; set; }
    }


}
