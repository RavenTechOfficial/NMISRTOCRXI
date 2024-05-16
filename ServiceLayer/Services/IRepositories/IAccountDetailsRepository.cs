using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IAccountDetailsRepository : IRepository<AccountDetail>
	{
		void Update(AccountDetail entity);
	}
}