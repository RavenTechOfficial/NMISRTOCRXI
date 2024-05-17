using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class PassedForSlaughter
    {
        [Key]
        public int Id { get; set; }
        public int NoOfHeads { get; set; }
        public double Weight { get; set; }
		[ForeignKey("ConductOfInspection")]
		public int ConductOfInspectionId { get; set; }
		public virtual ConductOfInspection? ConductOfInspection { get; set; }
		//[ForeignKey("ReceivingReport")]
		//public Guid ReceivingReportId { get; set; }
		//public virtual ReceivingReport? ReceivingReport { get; set; }
	}
}
