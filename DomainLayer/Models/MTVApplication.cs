using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class MTVApplication
    {
		[Key]
		public int Id { get; set; }
		public ApplicationType applicationtype { get; set; }
		public string AccreditionNo { get; set; }
		public string OwnerFname { get; set; }
		public string OwnerMname { get; set; }
		public string OwnerLname { get; set; }
		public string? Address { get; set; }
		public string Email { get; set; }
		public string TelNo { get; set; }
		public string FaxNo { get; set; }
		public string Status { get; set; }
		public VehicleInfo? Vehicle { get; set; }
		public Helper? Helper { get; set; }
		public Driver? Driver { get; set; }
	}
}
