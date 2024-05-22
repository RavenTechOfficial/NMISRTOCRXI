using DomainLayer.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{ 

// Add profile data for application users by adding properties to the thesisUser class
    public class AccountDetails : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        [ForeignKey("MeatEstablishment")]
        public Guid? MeatEstablishmentId { get; set; }
        public MeatEstablishment? MeatEstablishment { get; set; }

    }
}

