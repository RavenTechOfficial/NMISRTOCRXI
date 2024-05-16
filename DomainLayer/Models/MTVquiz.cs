using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
	public class MTVQuiz
	{
		[Key]
		public Guid Id { get; set; }
		[ForeignKey("MTVApplication")]
		public Guid? MTVApplicationId { get; set; }
		public virtual MTVApplication MTVApplication { get; set; }
		public PassOrFail passorfail { get; set; }
	}
}
