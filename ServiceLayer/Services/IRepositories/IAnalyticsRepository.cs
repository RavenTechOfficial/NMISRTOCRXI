using DomainLayer.Models.ViewModels;
using DomainLayer.Enum;

namespace ServiceLayer.Services.IRepositories
{
    public interface IAnalyticsRepository
    {
        public AnalyticsViewModel GetTotalOfMeatPerTimeSeries(string timeseries, List<Species> species, DateTime startDate, DateTime endDate);
    }
}
