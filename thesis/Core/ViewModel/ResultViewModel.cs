using thesis.Areas.Identity.Data;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.ViewModel
{
    public class ResultViewModel
    {
        public List<MeatInspectionReport> MeatInspectionData { get; set; }
        public List<ReceivingReport> ReceivingReportData { get; set; }
        public thesis.Models.MeatInspectionReport MeatInspectionReports { get; set; }



        public int Id { get; set; }
        public int MeatInspectionReportId { get; set; }
        public DateTime DateReceived { get; set; }
        public ReceivingReport? ReceivingReport { get; set; }
        public AccountDetails? AccountDetails { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? LicenseToOperateNumber { get; set; }
        public string? AccountDetailsId { get; set; }
        public string MeatInspector { get; set; }
        public string VerifiedBy { get; set; }



        public int? ReceivingReportId { get; set; }
        public Species? Specie { get; set; }
        public CategoryOfFoodAnimals? Category { get; set; }
        public string ReceivingBy { get; set; }
        public DateTime RecTime { get; set; }
        public double LiveWeight { get; set; }
        public int NoOfHeads { get; set; }


        public DateTime RepDate { get; set; }
        public int RepHeads { get; set; }
        public double DressedWeight { get; set; }
        public CertificateStatus? CertificateStatus { get; set; }

        public string origin { get; set; }

        public string MeatDealerFName { get; set; }
        public string MeatDealerMName { get; set; }
        public string MeatDealerLName { get; set; }
        public string MeatDealerAddress { get; set; }
        public string MeatDealerContactNo { get; set; }

        public string UID { get; set; }
        public string MeatEstablishmentName { get; set; }
        public string MeatEstablishmentAddress { get; set; }
        public string MeatEstablishmentLTO { get; set; }
        public string ShippingDocuments { get; set; }

    }
}
