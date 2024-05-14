using Microsoft.AspNetCore.Http;

namespace DomainLayer.Models.ViewModels
{
	public class MtvPaymentViewModel
	{
		public IFormFile PaymentReceipt { get; set; }
		public string SOA { get; set; }
		public DateTime Date { get; set; }
		public string Email { get; set; }
	}
}
