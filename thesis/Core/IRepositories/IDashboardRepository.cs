using thesis.Core.ViewModel;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.IRepositories
{
    public interface IDashboardRepository
    {
        Task<ICollection<TotalNoFitForHumanConsumption>> GetTotalNoFitForHumanConsumptions();
        TotalWeightViewModel GetTotalOfMeatPerTimeSeries(Species species);
    }
}
