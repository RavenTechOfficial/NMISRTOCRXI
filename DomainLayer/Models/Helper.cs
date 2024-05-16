using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class Helper
	{
		[Key]
		public Guid? Id { get; set; }
		public string? FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string? LastName { get; set; }
		public string? Address { get; set; }
		public string? Email { get; set; }
		public string? ContactNo { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}
