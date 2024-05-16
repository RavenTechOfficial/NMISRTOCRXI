using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;

namespace DomainLayer.Models
{
    public class MeatInspectionReport
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime ReportDate { get; set; }
        public string? VerifiedByPOSMSHead { get; set; }
        [ForeignKey("ReceivingReport")]
        public Guid? ReceivingReportId { get; set; }
        public virtual MeatInspectionReceivingReport? ReceivingReport { get; set; }

        [ForeignKey("AccountDetails")]
        public string? InspectedById { get; set; }
        public virtual AccountDetail? InspectedBy { get; set; }

    }
}
