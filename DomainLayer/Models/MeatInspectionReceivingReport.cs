using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class MeatInspectionReceivingReport
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int BatchCode { get; set; }
        public Species Species { get; set; }
        public CategoryOfFoodAnimals Category { get; set; }
        public int NumberOfHeads { get; set; }
        public double LiveWeight { get; set; }
        [ForeignKey("MeatDealer")]
        public Guid? MeatDealerId { get; set; }
        public MeatDealer? MeatDealer { get; set; }
        public string Origin { get; set; }
        public string ShippingDocuments { get; set; }
        public int HoldingPenNo { get; set; }
        public string ReceivingBy { get; set; }
        [ForeignKey("AccountDetails")]
        public string? ProcessedById { get; set; }
        public AccountDetail? ProcessedBy { get; set; }
        public InspectionStatus? InspectionStatus { get; set; }


        public MeatInspectionReport MeatInspectionReports { get; set; }
        public IEnumerable<MeatInspectionAntemortem> Antemortems { get; set; }
		public IEnumerable<MeatInspectionPassedForSlaughter> PassedForSlaughters { get; set; }
		public IEnumerable<MeatInspectionPostmortem> Postmortems { get; set; }
		public IEnumerable<MeatInspectionTotalNoFitForHumanConsumption> TotalNoFitForHumanConsumptions { get; set; } 
        public MeatInspectionSummaryAndDistributionOfMIC SummaryAndDistributionOfMICs { get; set; } 
    }
}
