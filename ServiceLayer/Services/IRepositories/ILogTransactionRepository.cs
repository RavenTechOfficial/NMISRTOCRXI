using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface ILogTransactionRepository : IRepository<LogTransaction>
	{
		void Update(LogTransaction entity);
	}
}