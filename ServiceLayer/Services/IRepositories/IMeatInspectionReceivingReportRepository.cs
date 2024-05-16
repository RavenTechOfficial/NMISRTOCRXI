using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
	public interface IMeatInspectionReceivingReportRepository : IRepository<MeatInspectionReceivingReport>
	{
		void Update(MeatInspectionReceivingReport entity);
	}
}