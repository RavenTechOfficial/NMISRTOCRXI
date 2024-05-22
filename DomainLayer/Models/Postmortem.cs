using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class Postmortem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ReceivingReport")]
        public Guid ReceivingReportId { get; set; }
        public virtual ReceivingReport? ReceivingReport { get; set; }
        public AnimalPart AnimalPart { get; set; }
        public Cause Cause { get; set; }
        public double Weight { get; set; }
        public int NoOfHeads { get; set; }
        public string? Image1 { get; set; } // Nullable string property
        public string? Image2 { get; set; } // Nullable string property
        public string? Image3 { get; set; } // Nullable string property
    }
}
