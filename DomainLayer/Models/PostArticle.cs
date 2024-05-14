using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
	public class PostArticle
	{
		[Key]
		public int Id { get; set; }
		public string Author { get; set; }
		public string Label { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string? Image { get; set; }
		public string Introduction { get; set; }
		public string Body { get; set; }
		public string Conclusion { get; set; }
		public string References { get; set; }
		public DateTime Date { get; set; }


	}
}
