using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
	public class PaymentwPlateNoViewModel
	{
		public string PaymentReceipt { get; set; }
		public DateTime Date { get; set; }
		public string Email { get; set; }
		public string SOA { get; set; }
		public MTVApplication MTVApplication { get; set; }
		public string PlateNo { get; set; }
	}
}
