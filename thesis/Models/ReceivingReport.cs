using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int LiveWeight { get; set; }
        [ForeignKey("MeatDealers")]
        public int MeatDealersId { get; set; }
        public MeatDealers MeatDealers { get; set; }
        public string Origin { get; set; }
        public ShippingDocuments ShippingDoc { get; set; }
        public int HoldingPenNo { get; set; }
        public string ReceivingBy { get; set; }
        [ForeignKey("Receiving")]
        public int ReceivingId { get; set; }
        public Receiving Receiving { get; set; }

    }
}
