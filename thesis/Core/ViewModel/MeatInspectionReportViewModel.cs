using thesis.Data.Enum;

namespace thesis.Core.ViewModel
{
	public class MeatInspectionReportViewModel
	{
		public DateTime InspectDate { get; set; } = DateTime.Now;
		public string? VerifiedByPOSMSHead { get; set; }
		public int ReceivingReportId { get; set; }
		public DateTime ReceivedDate { get; set; }
		public Species Species { get; set; }
		public int NoOfHeads { get; set; }
		public int MeatDealersId { get; set; }
	}
}
