using System.ComponentModel.DataAnnotations;

namespace thesis.Models
{
	public class Feedback
	{
		[Key]
		public int Id { get; set; }
		public int HighlySatisfied { get; set; }
		public int Satisfied { get; set; }
		public int Neutral { get; set; }
		public int Dissatisfied { get; set; }
		public int HighlyDissatisfied { get; set; }
	}
}
