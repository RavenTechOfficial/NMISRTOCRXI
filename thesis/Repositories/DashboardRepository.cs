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
			var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			var startDateOfWeek = DateTime.Now.AddDays(-7);
			var startDateOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			var startDateOfYear = new DateTime(DateTime.Now.Year, 1, 1);


			var dailyWeight = InspectionWithinDataRange(currentDate);
            var weeklyWeight = InspectionWithinDataRange(startDateOfWeek);
            var monthlyWeight = InspectionWithinDataRange(startDateOfMonth);
            var yearlyWeight = InspectionWithinDataRange(startDateOfYear);
            var totalWeight= _context.totalNoFitForHumanConsumptions
                .Sum(p => p.DressedWeight);

            


            return new TotalWeightViewModel
            {
                TotalWeight = totalWeight,
                DailyWeight = dailyWeight,
                WeeklyWeight = weeklyWeight,
                MonthlyWeight = monthlyWeight,
                YearlyWeight = yearlyWeight
            };
        }

		public TotalWeightViewModel ConductOfInspectionTimeSeries()
		{
			var startDateOfYear = new DateTime(DateTime.Now.Year, 1, 1);

			var suspect = Issue.Suspect;
            var rejected = Issue.Rejected;
            var condemned = Issue.Condemned;

            var monthlySuspect = InspectionDate(startDateOfYear, suspect);
            var monthlyRejected = InspectionDate(startDateOfYear, rejected);
            var monthlyCondemned = InspectionDate(startDateOfYear, condemned);

            return new TotalWeightViewModel
            {
				MonthlySuspect = monthlySuspect,
                MonthlyRejected = monthlyRejected,  
                MonthlyCondemned = monthlyCondemned
			};
		}

		public TotalWeightViewModel AreaChartTimeSeries()
		{
			throw new NotImplementedException();
		}

		public int InspectionWithinDataRange(DateTime dates)
        {
            var inspectionWithinDataRange = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= dates.Date)
                .Sum(p => p.DressedWeight);

            return inspectionWithinDataRange;
        }
        public int InspectionDate(DateTime dates, Issue issue)
        {
            var conduct = _context.ConductOfInspections
                .Include(p => p.Antemortem.MeatInspectionReport)
                .Where(p => p.Antemortem.MeatInspectionReport.RepDate.Date >= dates.Date && p.Issue == issue)
                .Sum(p => p.NoOfHeads);

            return conduct;
        }

		
	}
}
