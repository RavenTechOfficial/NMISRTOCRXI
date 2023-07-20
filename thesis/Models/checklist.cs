using System.ComponentModel.DataAnnotations;
using thesis.Data.Enum;

namespace thesis.Models
{
	public class checklist
	{
		[Key]
		public int Id { get; set; }
		public MTVquiz MTVquiz { get; set; }
		public passorfail passorfail { get; set; }
	}
}
