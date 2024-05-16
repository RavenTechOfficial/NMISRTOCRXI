using System.ComponentModel.DataAnnotations;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
	public class Driver
	{
		[Key]
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public string LicenseFront { get; set; }
		public string LicenseBack { get; set; }
		public string? Address { get; set; }
		public string Email { get; set; }
		public string ContactNo { get; set; }
		public Gender Gender { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
