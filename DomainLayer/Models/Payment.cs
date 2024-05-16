using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class Payment
    {
		[Key]
		public Guid Id { get; set; }
		public string PaymentReceipt { get; set; }
		public DateTime Date { get; set; }
		public string Email { get; set; }
		public string SOA { get; set; }
        public MTVApplication MTVApplication { get; set; }
    }
}
