using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class SummaryAndDistributionOfMIC
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TotalNoFitForHumanConsumption")]
        public int TotalNoFitForHumanConsumptionId { get; set; }
        public totalNoFitForHumanConsumptions TotalNoFitForHumanConsumption { get; set; }
        public string DestinationName { get; set; }
        public string DestinationAddress { get; set; }
        public CertificateStatus CertificateStatus { get; set; }
    }
}
