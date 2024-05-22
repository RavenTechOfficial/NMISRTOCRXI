using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class MeatDealers
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        [ForeignKey("MeatEstablishment")]
        public Guid MeatEstablishmentId { get; set; }
        public MeatEstablishment MeatEstablishment { get; set; }
    }
}
