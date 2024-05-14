using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class Helper
	{
		[Key]
		public int? Id { get; set; }
		public string? HelperFname { get; set; }
		public string? HelperMname { get; set; }
		public string? HelperLname { get; set; }
		public string? Address { get; set; }
		public string? Email { get; set; }
		public string? TelNo { get; set; }
		public DateTime? birthdate { get; set; }
	}
}
