using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMTVQuizRepository : IRepository<MTVQuiz>
	{
		void Update(MTVQuiz entity);
	}
}