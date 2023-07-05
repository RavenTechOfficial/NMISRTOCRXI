using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class PassedForSlaughter
    {
        [Key]
        public int Id { get; set; }
        public int NoOfHeads { get; set; }
        public int Weight { get; set; }
        [ForeignKey("ConductOfInspection")]
        public int ConductOfInspectionId { get; set; }
        public ConductOfInspection ConductOfInspection { get; set; }
    }
}
