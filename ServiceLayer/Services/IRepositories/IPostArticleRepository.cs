using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IPostArticleRepository : IRepository<PostArticle>
	{
		void Update(PostArticle entity);
	}
}