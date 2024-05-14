using DomainLayer.Models.ViewModels;
using DomainLayer.Enum;
using DomainLayer.Models;

namespace thesis.Core.IRepositories
{
    public interface IDashboardRepository
    {
        Task<ICollection<totalNoFitForHumanConsumptions>> GetTotalNoFitForHumanConsumptions();
        TotalWeightViewModel GetTotalOfMeatPerTimeSeries();

    }
}
