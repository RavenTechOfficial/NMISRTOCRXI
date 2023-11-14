using thesis.Areas.Identity.Data;

namespace thesis.Core.ViewModel
{
	public class PostArticleViewModel
	{
        
        public string Author { get; set; }
		public string Label { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IFormFile Image { get; set; }
		public string Introduction { get; set; }
		public string Body { get; set; }
		public string Conclusion { get; set; }
		public string References { get; set; }
		public DateTime Date { get; set; }
	}
}
