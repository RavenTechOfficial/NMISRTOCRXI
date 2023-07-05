using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class ConductOfInspection
    {
        [Key]
        public int Id { get; set; }
        public Issue Issue { get; set; }
        public int NoOfHeads { get; set; }
        public int Weight { get; set; }
        public Cause Cause { get; set; }
        [ForeignKey("Antemortem")]
        public int AntemortemId { get; set; }
        public Antemortem Antemortem { get; set; }
    }
}
