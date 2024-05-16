using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatInspectionReceivingRepository : IRepository<MeatInspectionReceiving>
	{
		void Update(MeatInspectionReceiving entity);
	}
}