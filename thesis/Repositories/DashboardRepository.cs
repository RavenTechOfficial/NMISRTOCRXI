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

			//cards
			var dailyWeight = InspectionWithinDataRange(currentDate);
            var weeklyWeight = InspectionWithinDataRange(startDateOfWeek);
            var monthlyWeight = InspectionWithinDataRange(startDateOfMonth);
            var yearlyWeight = InspectionWithinDataRange(startDateOfYear);
            var totalWeight= _context.totalNoFitForHumanConsumptions
                .Sum(p => p.DressedWeight);


            //area cahrt
            var monthRangesApproved = new List<int>();
            var monthRangesCondemned = new List<int>();
            //bar chart
            var suspects = new List<int>();
            var condemneds = new List<int>();
            var passes = new List<int>();

            for (DateTime date = startDateOfYear; date < currentDate; date = date.AddMonths(1))
            {
                var startOfMonth = date;
                var endOfMonth = date.AddMonths(1);

                var monthRangeApproved = AreaChartTimeSeriesRangeApproved(startOfMonth, endOfMonth);
                var monthRangeCondemned = AreaChartTimeSeriesRangeCondemned(startOfMonth, endOfMonth);

                var suspect = BarChartTimeSeriesAntemortem(Issue.Suspect, startOfMonth, endOfMonth);
                var condemned = BarChartTimeSeriesAntemortem(Issue.Condemned, startOfMonth, endOfMonth);
                var pass = BarChartTimeSeriesAntemortem(Issue.Pass, startOfMonth, endOfMonth);

                monthRangesApproved.Add(monthRangeApproved);
                monthRangesCondemned.Add(monthRangeCondemned);

                suspects.Add(suspect);
                condemneds.Add(condemned);
                passes.Add(pass);
            }

            var monthAbbreviations = new string[]
			{
				"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
			};

			var currentMonth = DateTime.Now.Month;
			var monthAbbreviationsArray = monthAbbreviations.Take(currentMonth).ToArray();



			return new TotalWeightViewModel
            {
                TotalWeight = totalWeight,
                DailyWeight = dailyWeight,
                WeeklyWeight = weeklyWeight,
                MonthlyWeight = monthlyWeight,
                YearlyWeight = yearlyWeight,
				monthlyRangeApproved = monthRangesApproved,
				monthlyRangeCondemned = monthRangesCondemned,
				monthAbbreviationsArray = monthAbbreviationsArray,
                Pass = passes,
                Condemned = condemneds,
                Suspect = suspects

			};
        }

        public int BarChartTimeSeriesAntemortem(Issue issue, DateTime start, DateTime end)
        {
            var barchart = _context.ConductOfInspections
                .Include(p => p.MeatInspectionReport)
                .Where(p => p.Issue == issue
                && p.MeatInspectionReport.RepDate.Date >= start.Date
                && p.MeatInspectionReport.RepDate.Date <= end.Date)
                .Sum(p => p.NoOfHeads);

            return barchart;
        }


        public int AreaChartTimeSeriesRangeApproved(DateTime start, DateTime end)
        {
			var areaChart = _context.totalNoFitForHumanConsumptions
				.Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport)
				.Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date >= start.Date
				&& p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date <= end.Date)
				.Sum(p => p.DressedWeight);

            return areaChart;
		}

		public int AreaChartTimeSeriesRangeCondemned(DateTime start, DateTime end)
		{
			var areaChart = _context.totalNoFitForHumanConsumptions
				.Include(p => p.Postmortem)
				.Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date >= start.Date
				&& p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date <= end.Date)
				.Sum(p => p.Postmortem.Weight);

			return areaChart;
		}


		public int InspectionWithinDataRange(DateTime dates)
        {
            var inspectionWithinDataRange = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date >= dates.Date)
                .Sum(p => p.DressedWeight);

            return inspectionWithinDataRange;
        }
        public int InspectionDate(DateTime dates, Issue issue)
        {
            var conduct = _context.ConductOfInspections
                .Include(p => p.MeatInspectionReport)
                .Where(p => p.MeatInspectionReport.RepDate.Date >= dates.Date && p.Issue == issue)
                .Sum(p => p.NoOfHeads);

            return conduct;
        }

		
	}
}
