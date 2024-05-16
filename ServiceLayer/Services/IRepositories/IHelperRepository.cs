using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IHelperRepository : IRepository<Helper>
	{
		void Update(Helper entity);
	}
}