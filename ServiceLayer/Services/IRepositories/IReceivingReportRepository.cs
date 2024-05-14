using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IReceivingReportRepository
    {
        Task<ICollection<ReceivingReport>> GetAllRReportsAsync();
        int GetTotalOfHeads();
    }
}
