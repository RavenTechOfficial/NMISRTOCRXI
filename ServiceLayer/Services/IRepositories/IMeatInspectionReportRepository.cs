using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IMeatInspectionReportRepository : IRepository<MeatInspectionReport>
    {
        void Update(MeatInspectionReport entity);
    }
}
