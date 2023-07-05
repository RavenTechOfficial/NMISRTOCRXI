using thesis.Core.ViewModel;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.IRepositories
{
    public interface IAnalyticsRepository
    {
        public IList<int> GetAnalytics(Species species, string dateTime);
        public IList<string> GetDates(Species species, string dateTime);
    }
}
