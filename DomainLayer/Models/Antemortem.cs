using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class Antemortem
    {
        [Key]
        public Guid Id { get; set; }
        public Issue Issue { get; set; }
        public int NoOfHeads { get; set; }
        public double Weight { get; set; }
        public Cause Cause { get; set; }
        [ForeignKey("ReceivingReport")]
        public Guid ReceivingReportId { get; set; }
        public virtual ReceivingReport? ReceivingReport { get; set; }
    }
}
