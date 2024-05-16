using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IResultRepository : IRepository<Result>
	{
		void Update(Result entity);
	}
}