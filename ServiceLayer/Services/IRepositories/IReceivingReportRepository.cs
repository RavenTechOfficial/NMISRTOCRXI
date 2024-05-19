using DomainLayer.Models;
using DomainLayer.Models.ViewModels;

namespace ServiceLayer.Services.IRepositories
{
    public interface IReceivingReportRepository : IRepository<ReceivingReport>
    {
        void Update(ReceivingReport entity);
    }
}
