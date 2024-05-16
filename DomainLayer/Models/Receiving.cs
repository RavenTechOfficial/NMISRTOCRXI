using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;

namespace DomainLayer.Models
{
    public class Receiving
    {
        public Guid Id { get; set; }
        public DateTime RecDate { get; set; }
        [ForeignKey("AccountDetails")]
        public string ReceivedById { get; set; }
        public AccountDetails ReceivedBy { get; set; }
    }
}
