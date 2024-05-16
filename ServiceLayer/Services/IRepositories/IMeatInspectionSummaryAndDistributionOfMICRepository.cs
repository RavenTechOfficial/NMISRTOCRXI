using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatInspectionSummaryAndDistributionOfMICRepository : IRepository<MeatInspectionSummaryAndDistributionOfMIC>
	{
		void Update(MeatInspectionSummaryAndDistributionOfMIC entity);
	}
}