using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IMeatInspectionReportRepository
    {
        Task<ICollection<MeatInspectionReport>> GetAllMeatInspectionReports();

    }
}
