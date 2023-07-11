using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class Antemortem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MeatInspectionReport")]
        public int MeatInspectionReportId { get; set; }
        public MeatInspectionReport MeatInspectionReport { get; set; }

    }
}
