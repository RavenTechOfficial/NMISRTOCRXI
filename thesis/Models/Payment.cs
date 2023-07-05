using System.ComponentModel.DataAnnotations;

namespace thesis.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string PaymentReceipt { get; set; }
        public MTVApplication MTVApplication { get; set; }
    }
}
