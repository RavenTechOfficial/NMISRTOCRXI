using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatInspectionPassedForSlaughterRepository : IRepository<MeatInspectionPassedForSlaughter>
	{
		void Update(MeatInspectionPassedForSlaughter entity);
	}
}