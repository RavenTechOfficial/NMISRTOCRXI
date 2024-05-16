namespace DomainLayer.Models.ViewModels
{
    public class MtvDashboardViewModel
	{
		public IEnumerable<AccountDetail> AccountDetails { get; set; }
		public IEnumerable<CheckList> Checklists { get; set; }
		public IEnumerable<MTVPayment> Payments { get; set; }
	}
}
