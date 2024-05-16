using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class MTVApplication
    {
		[Key]
		public Guid Id { get; set; }
		public ApplicationType ApplicationType { get; set; }
		public string AccreditationNo { get; set; }
		public string OwnerFirstName { get; set; }
		public string? OwnerMiddleName { get; set; }
		public string OwnerLastName { get; set; }
		public string? Address { get; set; }
		public string Email { get; set; }
		public string ContactNo { get; set; }
		public string FaxNo { get; set; }
		public string Status { get; set; }
		public VehicleInfo? VehicleInfo { get; set; }
		public Helper? Helper { get; set; }
		public Driver? Driver { get; set; }
	}
}
