using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class MTVPayment
    {
		[Key]
		public Guid Id { get; set; }
		public string PaymentReceipt { get; set; }
		public DateTime Date { get; set; }
		public string Email { get; set; }
		public string SOA { get; set; }
		[ForeignKey("MTVApplication")]
		public Guid? MTVApplicationId { get; set; }
		public virtual MTVApplication MTVApplication { get; set; }
    }
}
