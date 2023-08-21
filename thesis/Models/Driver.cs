using System.ComponentModel.DataAnnotations;
using thesis.Data.Enum;

namespace thesis.Models
{
	public class Driver
	{
		[Key]
		public int Id { get; set; }
		public string DriverFname { get; set; }
		public string DriverMname { get; set; }
		public string DriverLname { get; set; }
		public string LicenseFront { get; set; }
		public string LicenseBack { get; set; }
		public string? Address { get; set; }
		public string Email { get; set; }
		public string TelNo { get; set; }
		public gender gender { get; set; }
		public DateTime birthdate { get; set; }
	}
}
