using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatInspectionAntemortemRepository : IRepository<MeatInspectionAntemortem>
	{
		void Update(MeatInspectionAntemortem entity);
	}
}