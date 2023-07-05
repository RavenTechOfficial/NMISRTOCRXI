using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using thesis.Models;

namespace thesis.Areas.Identity.Data;

// Add profile data for application users by adding properties to the thesisUser class
public class AccountDetails : IdentityUser
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string middleName { get; set; }
    public string address { get; set; }
    public string contactNo { get; set; }
    public string image { get; set; }

}

