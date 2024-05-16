using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class LogTransaction
	{

		[Key]
		public Guid Id { get; set; }
		[Required]
		public string LogName { get; set; }
		[Required]
		public string LogPurpose { get; set; }
		[Required]
		public DateTime LogDate { get; set; }
    }
}
