using thesis.Models;

namespace thesis.Core.IRepositories
{
    public interface IMeatInspectionReportRepository
    {
        Task<ICollection<MeatInspectionReport>> GetAllMeatInspectionReports();

    }
}
