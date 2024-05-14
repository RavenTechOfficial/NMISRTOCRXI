using DomainLayer.Models;

namespace thesis.Core.IRepositories
{
    public interface IReceivingReportRepository
    {
        Task<ICollection<ReceivingReport>> GetAllRReportsAsync();
        int GetTotalOfHeads();
    }
}
