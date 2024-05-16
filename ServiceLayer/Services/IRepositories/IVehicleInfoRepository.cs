using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IVehicleInfoRepository : IRepository<VehicleInfo>
	{
		void Update(VehicleInfo entity);
	}
}