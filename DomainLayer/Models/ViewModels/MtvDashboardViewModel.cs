namespace DomainLayer.Models.ViewModels
{
    public class MtvDashboardViewModel
	{
		public IEnumerable<AccountDetails> AccountDetails { get; set; }
		public IEnumerable<CheckList> Checklists { get; set; }
		public IEnumerable<Payment> Payments { get; set; }
	}
}
