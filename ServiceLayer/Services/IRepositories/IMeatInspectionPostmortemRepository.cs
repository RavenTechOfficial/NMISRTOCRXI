using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatInspectionPostmortemRepository : IRepository<MeatInspectionPostmortem>
	{
		void Update(MeatInspectionPostmortem entity);
	}
}