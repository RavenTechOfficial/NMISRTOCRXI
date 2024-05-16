using System.ComponentModel.DataAnnotations;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
	public class MTVquiz
	{
		[Key]
		public Guid Id { get; set; }
		public MTVApplication MTVApplication { get; set; }
		public PassOrFail passorfail { get; set; }
	}
}
