using thesis.Core.ViewModel;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.IRepositories
{
    public interface IDashboardRepository
    {
        Task<ICollection<totalNoFitForHumanConsumptions>> GetTotalNoFitForHumanConsumptions();
        TotalWeightViewModel GetTotalOfMeatPerTimeSeries();
    }
}
