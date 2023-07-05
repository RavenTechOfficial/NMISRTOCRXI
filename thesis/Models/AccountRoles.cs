using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class AccountRoles
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AccountDetails")]
        public string AccountDetailsId { get; set; }
        public AccountDetails AccountDetails { get; set; }
        public Roles Roles { get; set; }
        [ForeignKey("MeatEstablishment")]
        public int? MeatEstablishmentId { get; set; }
        public MeatEstablishment? MeatEstablishment { get; set;}
        
    }
}
