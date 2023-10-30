using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class ReceivingReport
    {
        [Key]
        public int Id { get; set; }
        public DateTime RecTime { get; set; }
        public int BatchCode { get; set; }
        public Species Species { get; set; }
        public CategoryOfFoodAnimals Category { get; set; }
        public int NoOfHeads { get; set; }
        public double LiveWeight { get; set; }
        [ForeignKey("MeatDealers")]
        public int? MeatDealersId { get; set; }
        public MeatDealers? MeatDealers { get; set; }
        public string Origin { get; set; }
        public string ShippingDoc { get; set; }
        public int HoldingPenNo { get; set; }
        public string ReceivingBy { get; set; }
        [ForeignKey("AccountDetails")]
        public string? AccountDetailsId { get; set; }
        public AccountDetails? AccountDetails { get; set; }
        public InspectionStatus? InspectionStatus { get; set; }

    }
}
