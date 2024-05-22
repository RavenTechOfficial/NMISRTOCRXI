using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface ITotalNoFitForHumanConsumptionRepository : IRepository<TotalNoFitForHumanConsumptions>
    {
        void Update(TotalNoFitForHumanConsumptions entity);
    }
}
