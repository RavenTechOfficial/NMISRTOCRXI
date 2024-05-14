using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class Antemortem
    {
        [Key]
        public int Id { get; set; }
        public Issue Issue { get; set; }
        public int NoOfHeads { get; set; }
        public double Weight { get; set; }
        public Cause Cause { get; set; }
        [ForeignKey("MeatInspectionReport")]
        public int MeatInspectionReportId { get; set; }
        public MeatInspectionReport? MeatInspectionReport { get; set; }
    }
}
