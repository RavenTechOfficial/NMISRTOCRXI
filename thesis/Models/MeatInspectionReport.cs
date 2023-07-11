using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class MeatInspectionReport
    {
        [Key]
        public int Id { get; set; }
        public DateTime RepDate { get; set; }
        public string VerifiedByPOSMSHead { get; set; }
        [ForeignKey("ReceivingReport")]
        public int? ReceivingReportId { get; set; }
        public ReceivingReport? ReceivingReport { get; set; }

    }
}
