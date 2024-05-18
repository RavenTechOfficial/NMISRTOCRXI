using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IReceivingReportRepository : IRepository<ReceivingReport>
    {
        void Update(ReceivingReport entity);
    }
}
