using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class ReceivingReport
    {
        public int Id { get; set; } 
        public string RecTime { get; set; }
        public int ShipmentBatchCode { get; set; }
        public string SpeciesTypeOfFoodAnimals { get; set; }
        public int NoOfHeads { get; set; }
        public int LiveWeighInKg { get; set; }
        public ICollection<ReceivingReportMeatEstablishment> receivingReportMeatEstablishments { get; set; }
        public string OriginOfFoodAnimals { get; set; }
        public string ShippingDocuments { get; set; }
        public int HoldingPenNo { get; set; }
        public string ReceivedBy { get; set; }
        public Receiving Receiving { get; set; }
    }
}
