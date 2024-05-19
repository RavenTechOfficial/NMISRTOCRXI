using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
    public class CreateReceivingReportViewModel
    {
        public DateTime RecTime { get; set; }
        public int BatchCode { get; set; }
        public Species Species { get; set; }
        public CategoryOfFoodAnimals Category { get; set; }
        public int NoOfHeads { get; set; }
        public double LiveWeight { get; set; }
        public Guid? MeatDealersId { get; set; }
        public string Origin { get; set; }
        public string ShippingDoc { get; set; }
        public int HoldingPenNo { get; set; }
        public string ReceivingBy { get; set; }
        public string? AccountDetailsId { get; set; }
        public InspectionStatus? InspectionStatus { get; set; }

        //      public MeatInspectionReport? MeatInspectionReport { get; set; }
        //      public IEnumerable<ConductOfInspection>? ConductOfInspection { get; set; }
        //      public IEnumerable<PassedForSlaughter>? PassedForSlaughter { get; set; }
        //      public IEnumerable<Postmortem>? Postmortems { get; set; }
        //      public IEnumerable<TotalNoFitForHumanConsumptions>? TotalNoFitForHumanConsumptions { get; set; }
        //public SummaryAndDistributionOfMIC? SummaryAndDistributionOfMIC { get; set; }
    }
}
