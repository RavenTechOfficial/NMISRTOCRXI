using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class MeatInspectionReport
    {
        [Key]
        public int Id { get; set; }
        public DateTime RepDate { get; set; }
        [ForeignKey("ReceivingReport")]
        public Guid? ReceivingReportId { get; set; }
        public ReceivingReport? ReceivingReport { get; set; }
        [ForeignKey("AccountDetails")]
        public string? AccountDetailsId { get; set; }
        public AccountDetails? AccountDetails { get; set; }
        public Guid UID { get; set; } 
        public string? Remarks { get; set; } 

    }
}
