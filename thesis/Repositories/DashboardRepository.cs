using Microsoft.EntityFrameworkCore;
using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly thesisContext _context;

        public DashboardRepository(thesisContext context)
        {
            _context = context;
        }
        public async Task<ICollection<TotalNoFitForHumanConsumption>> GetTotalNoFitForHumanConsumptions()
        {
            return await _context.totalNoFitForHumanConsumptions
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public TotalWeightViewModel GetTotalOfMeatPerTimeSeries(Species species)
        {
            var currentDate = DateTime.Now.AddDays(-1);
            var startDateOfWeek = DateTime.Now.AddDays(-7);
            var startDateOfMonth = DateTime.Now.AddDays(-31);
            var startDateOfYear = DateTime.Now.AddDays(-365);

            var dailyWeight = _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= currentDate.Date)
                .Sum(p => p.DressedWeightInKg);

            var weeklyWeight = _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= startDateOfWeek.Date)
                .Sum(p => p.DressedWeightInKg);

            var monthlyWeight = _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= startDateOfMonth.Date)
                .Sum(p => p.DressedWeightInKg);

            var yearlyWeight = _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species && p.Date.Date >= startDateOfYear.Date)
                .Sum(p => p.DressedWeightInKg);

            var totalWeight = _context.totalNoFitForHumanConsumptions
                .Where(p => p.Species == species)
                .Sum(p => p.DressedWeightInKg);

            return new TotalWeightViewModel
            {
                TotalWeight = totalWeight,
                SelectedSpecies = species,
                DailyWeight = dailyWeight,
                WeeklyWeight = weeklyWeight,
                MonthlyWeight = monthlyWeight,
                YearlyWeight = yearlyWeight
            };
        }
    }
}
