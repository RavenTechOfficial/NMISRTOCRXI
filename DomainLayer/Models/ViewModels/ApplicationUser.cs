using Microsoft.AspNetCore.Identity;
using DomainLayer.Models;

namespace DomainLayer.Models.ViewModels
{
    public class ApplicationUser
    {
        public AccountDetail User { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
