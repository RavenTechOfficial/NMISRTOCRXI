using DomainLayer.Models.ViewModels;
using DomainLayer.Enum;
using DomainLayer.Models;
using thesis.Repositories;

namespace thesis.Core.IRepositories
{
    public interface IAnalyticsRepository
    {
        public AnalyticsViewModel GetTotalOfMeatPerTimeSeries(string timeseries, List<Species> species, DateTime startDate, DateTime endDate);
    }
}
