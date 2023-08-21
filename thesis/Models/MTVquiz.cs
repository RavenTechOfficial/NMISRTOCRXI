using System.ComponentModel.DataAnnotations;
using thesis.Data.Enum;

namespace thesis.Models
{
	public class MTVquiz
	{
		[Key]
		public int Id { get; set; }
		public MTVApplication MTVApplication { get; set; }
		public passorfail passorfail { get; set; }
		public gender gender { get; set; }
		public string plateNo { get; set; }
	}
}
