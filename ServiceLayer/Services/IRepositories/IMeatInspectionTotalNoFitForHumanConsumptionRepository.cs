using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatInspectionTotalNoFitForHumanConsumptionRepository : IRepository<MeatInspectionTotalNoFitForHumanConsumption>
	{
		void Update(MeatInspectionTotalNoFitForHumanConsumption entity);
	}
}