using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly thesisContext _context;

        public AnalyticsRepository(thesisContext context)
        {
            _context = context;
        }
        public IList<int> GetAnalytics(Species species, string dateTime)
        {

            var time = dateTime == "Weekly" ? DateTime.Now.AddDays(-7) :
                        dateTime == "Monthly" ? DateTime.Now.AddDays(-31) :
                        dateTime == "Yearly" ? DateTime.Now.AddDays(-365) :
                        DateTime.Now.AddDays(-1);
            
            if (dateTime == "Total")
            {
                return _context.totalNoFitForHumanConsumptions
                    .Where(p => p.Species == species)
                    .OrderBy(p => p.Date)
                    .Select(p => p.DressedWeightInKg)
                    .ToList();
            }
            else
            {
                return _context.totalNoFitForHumanConsumptions
                    .Where(p => p.Species == species && p.Date.Date >= time.Date)
                    .OrderBy(p => p.Date)
                    .Select(p => p.DressedWeightInKg)
                    .ToList();
            }

          
        }

        public IList<string> GetDates(Species species, string dateTime)
        {
            var time = dateTime == "Weekly" ? DateTime.Now.AddDays(-7) :
                        dateTime == "Monthly" ? DateTime.Now.AddDays(-31) :
                        dateTime == "Yearly" ? DateTime.Now.AddDays(-365) :
                        DateTime.Now.AddDays(-1);

            if (dateTime == "Yearly")
            {
                return _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= time.Date)
                .OrderBy(p => p.Date)
                .Select(p => p.Date.ToString("MMMM"))
                .ToList();
            }
            else if(dateTime == "Monthly")
            {
                return _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= time.Date)
                .OrderBy(p => p.Date)
                .Select(p => p.Date.Month.ToString())
                .ToList();
            }
            else if(dateTime == "Weekly")
            {
                return _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= time.Date)
                .OrderBy(p => p.Date)
                .Select(p => p.Date.DayOfWeek.ToString())
                .ToList();
            }
            else if(dateTime == "Daily")
            {
                return _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= time.Date)
                .OrderBy(p => p.Date)
                .Select(p => p.Date.Day.ToString())
                .ToList();
            }
            else
            {
                return _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species)
                .OrderBy(p => p.Date)
                .Select(p => p.Date.Year.ToString())
                .ToList();
            }
        }
    }
}
