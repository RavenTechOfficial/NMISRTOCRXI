using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
    public class ReceivingReportViewModel
    {
        public Guid Id { get; set; }
        public DateTime RecTime { get; set; }
        public int BatchCode { get; set; }
        public Species Species { get; set; }
        public CategoryOfFoodAnimals Category { get; set; }
        public int NoOfHeads { get; set; }
        public double LiveWeight { get; set; }
        public string MeatDealer { get; set; }
        public string MeatEstablishment { get; set; }
        public string Origin { get; set; }
        public string ShippingDoc { get; set; }
        public int HoldingPenNo { get; set; }
        public string ReceivingBy { get; set; }
        public string? Inspector { get; set; }
        public InspectionStatus? InspectionStatus { get; set; }
        public MeatInspectionReport? MeatInspectionReport { get; set; } = new MeatInspectionReport();
        public List<AntemortemViewModel>? Antemortems { get; set; } = new List<AntemortemViewModel>();
        public PassedForSlaughter? PassedForSlaughter { get; set; } = new PassedForSlaughter();
        public List<PostmortemViewModel>? Postmortems { get; set; } = new List<PostmortemViewModel>();
        public TotalNoFitForHumanConsumptions? TotalNoFitForHumanConsumption { get; set; } = new TotalNoFitForHumanConsumptions();
    }
}
