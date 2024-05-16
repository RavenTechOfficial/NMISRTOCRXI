using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatDealerRepository : IRepository<MeatDealer>
	{
		void Update(MeatDealer entity);
	}
}