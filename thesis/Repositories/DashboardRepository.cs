using Humanizer;
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
        public async Task<ICollection<totalNoFitForHumanConsumptions>> GetTotalNoFitForHumanConsumptions()
        {
            throw new NotImplementedException();
        }

        public TotalWeightViewModel GetTotalOfMeatPerTimeSeries()
        {
            var currentDate = DateTime.Now.AddDays(-1);
            var startDateOfWeek = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek + 7));
            var startDateOfMonth = DateTime.Today.AddMonths(-1).AddDays(-(DateTime.Today.Day - 1));
            var startDateOfYear = new DateTime(DateTime.Now.AddYears(-1).Year, 1, 1);


            var dailyWeight = InspectionWithinDataRange(currentDate);
            var weeklyWeight = InspectionWithinDataRange(startDateOfWeek);
            var monthlyWeight = InspectionWithinDataRange(startDateOfMonth);
            var yearlyWeight = InspectionWithinDataRange(startDateOfYear);
            var totalWeight= _context.totalNoFitForHumanConsumptions
                .Sum(p => p.DressedWeight);

            //for bar data

            var dailyInspection = InspectionDate(currentDate);


            return new TotalWeightViewModel
            {
                TotalWeight = totalWeight,
                DailyWeight = dailyWeight,
                WeeklyWeight = weeklyWeight,
                MonthlyWeight = monthlyWeight,
                YearlyWeight = yearlyWeight
            };
        }

        public int InspectionWithinDataRange(DateTime dates)
        {
            var inspectionWithinDataRange = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= dates.Date)
                .Sum(p => p.DressedWeight);

            return inspectionWithinDataRange;
        }
        public int InspectionDate(DateTime dates)
        {
            var conduct = _context.ConductOfInspections
                .Include(p => p.Antemortem.MeatInspectionReport)
                .Where(p => p.Antemortem.MeatInspectionReport.RepDate.Date >= dates.Date)
                .Sum(p => p.NoOfHeads);

            return conduct;
        }
    }
}
