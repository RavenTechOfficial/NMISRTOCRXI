using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class TotalNoFitForHumanConsumptions
    {
        [Key]
        public int Id { get; set; }
        public int NoOfHeads { get; set; }
        public double OFALS { get; set; }
        public double DressedWeight { get; set; }
        [ForeignKey("ReceivingReport")]
        public Guid ReceivingReportId { get; set; }
        public virtual ReceivingReport? ReceivingReport { get; set; }

    }
}
