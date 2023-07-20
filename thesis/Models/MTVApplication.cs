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
		public string OwnerFname { get; set; }
		public string OwnerMname { get; set; }
		public string OwnerLname { get; set; }
		public string? Address { get; set; }
		public string Email { get; set; }
		public string TelNo { get; set; }
		public string FaxNo { get; set; }
		[ForeignKey("VehicleInfo")]
		public int? VehicleId { get; set; }
		public VehicleInfo? Vehicle { get; set; }
		[ForeignKey("Helper")]
		public int? HelperId { get; set; }
		public Helper? Helper { get; set; }

		[ForeignKey("Driver")]
		public int? DriverId { get; set; }
		public Driver? Driver { get; set; }
	}
}
