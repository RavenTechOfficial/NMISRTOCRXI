using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        public string? MeatEstablishment { get; set; }
    }
}
