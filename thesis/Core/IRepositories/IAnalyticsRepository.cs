using thesis.Core.ViewModel;
using thesis.Data.Enum;
using thesis.Models;
using thesis.Repositories;

namespace thesis.Core.IRepositories
{
    public interface IAnalyticsRepository
    {
        public AnalyticsViewModel GetTotalOfMeatPerTimeSeries();
    }
}
