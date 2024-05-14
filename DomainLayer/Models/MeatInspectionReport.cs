using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;

namespace DomainLayer.Models
{
    public class MeatInspectionReport
    {
        [Key]
        public int Id { get; set; }
        public DateTime RepDate { get; set; }
        public string? VerifiedByPOSMSHead { get; set; }
        [ForeignKey("ReceivingReport")]
        public int? ReceivingReportId { get; set; }
        public ReceivingReport? ReceivingReport { get; set; }
        [ForeignKey("AccountDetails")]
        public string? AccountDetailsId { get; set; }
        public AccountDetails? AccountDetails { get; set; }
        public string UID { get; set; }

    }
}
