using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
    }
}
