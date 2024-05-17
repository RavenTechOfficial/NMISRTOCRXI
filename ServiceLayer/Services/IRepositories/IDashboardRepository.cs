using DomainLayer.Models.ViewModels;
using DomainLayer.Enum;
using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IDashboardRepository
    {
        Task<ICollection<TotalNoFitForHumanConsumptions>> GetTotalNoFitForHumanConsumptions();
        TotalWeightViewModel GetTotalOfMeatPerTimeSeries();

    }
}
