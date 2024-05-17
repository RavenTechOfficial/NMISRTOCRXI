using DomainLayer.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{ 

// Add profile data for application users by adding properties to the thesisUser class
    public class AccountDetails : IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? middleName { get; set; }
        public string? address { get; set; }
        public string? contactNo { get; set; }
        public string? image { get; set; }
        public DateTime? birthdate { get; set; }
        public Roles? Roles { get; set; }
        public string? sex { get; set; }
        [ForeignKey("MeatEstablishment")]
        public int? MeatEstablishmentId { get; set; }
        public MeatEstablishment? MeatEstablishment { get; set; }

    }
}

