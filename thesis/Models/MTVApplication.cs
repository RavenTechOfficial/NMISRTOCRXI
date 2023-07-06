using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class MTVApplication
    {
        [Key]
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }   
        public string HelperName { get; set; }
        public string Seminar { get; set; }
        public string Quiz { get; set; }
        public EstablishmentType EstablishmentType { get; set; }
        public string VehicleDestination { get; set; }
        [ForeignKey("MTVDetails")]
        public int MTVDetailsId { get; set; }
        public MTVDetails MTVDetails { get; set; }
        [ForeignKey("AccountDetails")]
        public string AccountDetailsId { get; set; }
        public AccountDetails AccountDetails { get; set; }
    }
}
