using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface ICheckListRepository : IRepository<CheckList>
	{
		void Update(CheckList entity);
	}
}