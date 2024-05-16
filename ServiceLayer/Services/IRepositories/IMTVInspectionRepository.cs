using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMTVInspectionRepository : IRepository<MTVInspection>
	{
		void Update(MTVInspection entity);
	}
}