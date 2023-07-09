using Microsoft.AspNetCore.Identity;
using thesis.Areas.Identity.Data;

namespace thesis.Core.ViewModel
{
    public class ApplicationUser
    {
        public AccountDetails User { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
