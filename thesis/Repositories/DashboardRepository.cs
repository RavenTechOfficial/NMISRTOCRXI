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
		//area cahrt
		private List<double> monthRangesApproved;
		private List<double> monthRangesCondemned;
		//bar chart
		private List<double> suspects;
		private List<double> condemneds;
		private List<double> passes;

		private List<double> cattles;
		private List<double> carabaos;
		private List<double> swines;
		private List<double> goats;
		private List<double> chickens;
		private List<double> ducks;
		private List<double> horses;
		private List<double> sheeps;
		private List<double> ostrichs;
		private List<double> crocodiles;

		public DashboardRepository(thesisContext context)
        {
            _context = context;
			this.monthRangesApproved = new List<double>();
			this.monthRangesCondemned = new List<double>();
			this.suspects = new List<double>();
			this.condemneds = new List<double>();
			this.passes = new List<double>();
			this.cattles = new List<double>();
			this.carabaos = new List<double>();
			this.swines = new List<double>();
			this.goats = new List<double>();
			this.chickens = new List<double>();
			this.ducks = new List<double>();
			this.horses = new List<double>();
			this.sheeps = new List<double>();
			this.ostrichs = new List<double>();
			this.crocodiles = new List<double>();
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



            for (DateTime date = startDateOfYear; date < currentDate; date = date.AddMonths(1))
            {
                var startOfMonth = date;
                var endOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

				endOfMonth = endOfMonth < currentDate ? endOfMonth : currentDate;

				var monthRangeApproved = AreaChartTimeSeriesRangeApproved(startOfMonth, endOfMonth);
                var monthRangeCondemned = AreaChartTimeSeriesRangeCondemned(startOfMonth, endOfMonth);

                var suspect = BarChartTimeSeriesAntemortem(Issue.Suspect, startOfMonth, endOfMonth);
                var condemned = BarChartTimeSeriesAntemortem(Issue.Condemned, startOfMonth, endOfMonth);
                var pass = BarChartTimeSeriesAntemortemPass(startOfMonth, endOfMonth);

                var cattle = StackBarsSpeciesSeries(Species.Cattle, startOfMonth, endOfMonth);
                var carabao = StackBarsSpeciesSeries(Species.Carabao, startOfMonth, endOfMonth);
                var swine = StackBarsSpeciesSeries(Species.Swine, startOfMonth, endOfMonth);
                var goat = StackBarsSpeciesSeries(Species.Goat, startOfMonth, endOfMonth);
                var chicken = StackBarsSpeciesSeries(Species.Chicken, startOfMonth, endOfMonth);
                var duck = StackBarsSpeciesSeries(Species.Duck, startOfMonth, endOfMonth);
                var horse = StackBarsSpeciesSeries(Species.Horse, startOfMonth, endOfMonth);
                var sheep = StackBarsSpeciesSeries(Species.Sheep, startOfMonth, endOfMonth);
                var ostrich = StackBarsSpeciesSeries(Species.Ostrich, startOfMonth, endOfMonth);
                var crocodile = StackBarsSpeciesSeries(Species.Crocodile, startOfMonth, endOfMonth);

                monthRangesApproved.Add(monthRangeApproved);
                monthRangesCondemned.Add(monthRangeCondemned);

                cattles.Add(cattle);
                carabaos.Add(carabao);
                swines.Add(swine);
                goats.Add(goat);
                chickens.Add(chicken);
                ducks.Add(duck);
                horses.Add(horse);
                sheeps.Add(sheep);
                ostrichs.Add(ostrich);
                crocodiles.Add(crocodile);

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
                TotalWeight = Math.Round(totalWeight, 1),
                DailyWeight = Math.Round(dailyWeight, 1),
                WeeklyWeight = Math.Round(weeklyWeight, 1),
                MonthlyWeight = Math.Round(monthlyWeight,1),
                YearlyWeight = Math.Round(yearlyWeight,1),
				monthlyRangeApproved = monthRangesApproved.Select(x => Math.Round(x, 1)).ToList(),
				monthlyRangeCondemned = monthRangesApproved.Select(x => Math.Round(x, 1)).ToList(),
				monthAbbreviationsArray = monthAbbreviationsArray,
                Pass = passes,
                Condemned = condemneds,
                Suspect = suspects,
                Cattle = cattles,
                Carabao = carabaos,
                Swine = swines,
                Goat = goats,
                Chicken = chickens,
                Duck = ducks,
                Horse = horses,
                Sheep = sheeps,
                Ostrich = ostrichs,
                Crocodile = crocodiles,

            };
        }
        //na change

        private double StackBarsSpeciesSeries(Species species, DateTime start, DateTime end)
        {
            var stackchart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
                .Sum(p => p.DressedWeight);

            return stackchart;
        }
		private double BarChartTimeSeriesAntemortem(Issue issue, DateTime start, DateTime end)
        {
            var barchart = _context.ConductOfInspections
                .Include(p => p.MeatInspectionReport)
                .Where(p => p.Issue == issue
                && p.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
                && p.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date)
                .Sum(p => p.Weight);

            return barchart;
        }
		//na change
		private double BarChartTimeSeriesAntemortemPass(DateTime start, DateTime end)
		{
			var barchart = _context.PassedForSlaughters
				.Include(p => p.ConductOfInspection.MeatInspectionReport)
				.Where(p => p.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
				&& p.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date)
				.Sum(p => p.Weight);

			return barchart;
		}

		//na change
		private double AreaChartTimeSeriesRangeApproved(DateTime start, DateTime end)
        {
			var areaChart = _context.totalNoFitForHumanConsumptions
				.Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport)
				.Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
				&& p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date)
				.Sum(p => p.DressedWeight);

            return areaChart;
		}
		//na change
		private double AreaChartTimeSeriesRangeCondemned(DateTime start, DateTime end)
		{
			var areaChart = _context.totalNoFitForHumanConsumptions
				.Include(p => p.Postmortem)
				.Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
				&& p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date)
				.Sum(p => p.Postmortem.Weight);

			return areaChart;
		}

		//na change
		private double InspectionWithinDataRange(DateTime dates)
        {
            var inspectionWithinDataRange = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= dates.Date)
                .Sum(p => p.DressedWeight);

            return inspectionWithinDataRange;
        }
		//na change
		private int InspectionDate(DateTime dates, Issue issue)
        {
            var conduct = _context.ConductOfInspections
                .Include(p => p.MeatInspectionReport.ReceivingReport)
                .Where(p => p.MeatInspectionReport.ReceivingReport.RecTime.Date >= dates.Date && p.Issue == issue)
                .Sum(p => p.NoOfHeads);

            return conduct;
        }

		
	}
}
