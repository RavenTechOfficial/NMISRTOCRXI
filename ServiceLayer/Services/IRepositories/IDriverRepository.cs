using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IDriverRepository : IRepository<Driver>
	{
		void Update(Driver entity);
	}
}