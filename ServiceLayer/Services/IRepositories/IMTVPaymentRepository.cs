using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMTVPaymentRepository : IRepository<MTVPayment>
	{
		void Update(MTVPayment entity);
	}
}