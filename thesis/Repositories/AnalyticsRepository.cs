using Microsoft.EntityFrameworkCore;
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
        public AnalyticsViewModel GetTotalOfMeatPerTimeSeries(string timeseries, Species species, DateTime startDate, DateTime endDate)
        {

            
            var startOfDate = startDate;
            var currentDate = endDate;

            //var startDateOfWeek = DateTime.Now.AddDays(-7);
            //var startDateOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var currentMonth = DateTime.Now.Month;

            //area chart 
            var monthRangesApproved = new List<double>();
            var monthRangesCondemned = new List<double>();
            //horizontal bar chart
            var monthRangesOfHead = new List<int>();
            var monthRangesOfLiveWeight = new List<double>();
            //vertical bar chart
            var suspects = new List<double>();
            var condemneds = new List<double>();
            var passes = new List<double>();
            //piechart
            var animalType = new List<double>();
            //stack bars 100 chart
            var cattles = new List<double>();
            var carabaos = new List<double>();
            var swines = new List<double>();
            var goats = new List<double>();
            var chickens = new List<double>();
            var ducks = new List<double>();
            var horses = new List<double>();
            var sheeps = new List<double>();
            var ostrichs = new List<double>();
            var crocodiles = new List<double>();



            foreach (AnimalPart animalPart in Enum.GetValues(typeof(AnimalPart)))
            {
                var typeAnimals = PieChartAnimalTypeSeries(animalPart, startOfDate, currentDate);
                animalType.Add(typeAnimals);
            }



            for (DateTime date = startOfDate; date < currentDate; date = timeseries == "Monthly" ? date.AddMonths(1) : date.AddYears(1))
            {
                var startOfMonth = date;
                var endOfMonth = timeseries == "Monthly" ? date.AddMonths(1) : date.AddYears(1);

                var monthRangeApproved = AreaChartTimeSeriesRangeApproved(species, startOfMonth, endOfMonth);
                var monthRangeCondemned = AreaChartTimeSeriesRangeCondemned(species, startOfMonth, endOfMonth);

                var monthRangeOfHead = BarChartTimeSeriesRangeOfHead(species, startOfMonth, endOfMonth);
                var monthRangeOfLiveWeight = BarChartTimeSeriesRangeOfLiveWeight(species, startOfMonth, endOfMonth);
                
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

                var suspect = BarChartTimeSeriesAntemortem(species, Issue.Suspect, startOfMonth, endOfMonth);
                var condemned = BarChartTimeSeriesAntemortem(species, Issue.Condemned, startOfMonth, endOfMonth);
                var pass = BarChartTimeSeriesAntemortemPass(species, startOfMonth, endOfMonth);


                monthRangesApproved.Add(monthRangeApproved);
                monthRangesCondemned.Add(monthRangeCondemned);

                monthRangesOfHead.Add(monthRangeOfHead);
                monthRangesOfLiveWeight.Add(monthRangeOfLiveWeight);

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


            var currentDateFormatted = currentDate.ToString("MMM dd");

            var timeAbbreviationsList = new List<string>();

            if (timeseries == "Monthly")
            {
                var startMonth = startDate.Month;
                var currentMonths = endDate.Month;

                timeAbbreviationsList.AddRange(Enumerable.Range(startMonth, currentMonths - startMonth + 1)
                    .Select(month => startDate.AddMonths(month - startMonth).ToString("MMM dd")));
            }
            else if (timeseries == "Yearly")
            {
                var startYear = startDate.Year;
                var endYear = endDate.Year;

                timeAbbreviationsList.AddRange(Enumerable.Range(startYear, endYear - startYear + 1)
                    .Select(year => startDate.ToString("MMM") + " " + year));
            }

            // Add the current month and day if it's not already included
            if (!timeAbbreviationsList.Contains(currentDateFormatted))
            {
                timeAbbreviationsList.Add(currentDateFormatted);
            }

            var timeAbbreviationsArray = timeAbbreviationsList.ToArray();


            return new AnalyticsViewModel
            {
                monthlyRangeApproved = monthRangesApproved,
                monthlyRangeCondemned = monthRangesCondemned,
                monthlyRangeOfHead = monthRangesOfHead,
                monthlyRangeOfLiveWeight = monthRangesOfLiveWeight,
                animalTypeRange = animalType,
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
                Suspect = suspects,
                Condemned = condemneds,
                Pass = passes,
                monthAbbreviationsArray = timeAbbreviationsArray
            };

        }
        
        //from meatINspectionReport to Receiving DATE
        public double BarChartTimeSeriesAntemortem(Species species, Issue issue, DateTime start, DateTime end)
        {
           
            var barchart = _context.ConductOfInspections
            .Include(p => p.MeatInspectionReport)
            .Include(p => p.MeatInspectionReport.ReceivingReport)
            .Where(p => p.Issue == issue
                        && p.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
                        && p.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date
                        && p.MeatInspectionReport.ReceivingReport != null
                        && p.MeatInspectionReport.ReceivingReport.Species == species)
            .Sum(p => p.Weight);


            return barchart;
        }
        //from meatINspectionReport to Receiving DATE
        public double BarChartTimeSeriesAntemortemPass(Species species, DateTime start, DateTime end)
		{
			var barchart = _context.PassedForSlaughters
				.Include(p => p.ConductOfInspection.MeatInspectionReport.ReceivingReport)
				.Where(p => p.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
				&& p.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date
                && p.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
				.Sum(p => p.Weight);

			return barchart;
		}


        //from meatINspectionReport to Receiving DATE
        public double StackBarsSpeciesSeries(Species species, DateTime start, DateTime end)
        {
            var stackchart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
                .Sum(p => p.DressedWeight);

            return stackchart;
        }
        //from meatINspectionReport to Receiving DATE
        public double PieChartAnimalTypeSeries(AnimalPart animalPart, DateTime start, DateTime end)
        {
            var piechart = _context.Postmortems
                .Include(p => p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport)
                .Where(p => p.AnimalPart == animalPart
                    && p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
                    && p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date)
                .Sum(p => p.Weight);

            return piechart;
        }

        public int BarChartTimeSeriesRangeOfHead(Species species, DateTime start, DateTime end)
        {
            var hbarchart = _context.ReceivingReports
                .Where(p => p.RecTime >= start.Date && p.RecTime <= end.Date
                && p.Species == species)
                
                .Sum(p => p.NoOfHeads);

            return hbarchart;
        }

        public double BarChartTimeSeriesRangeOfLiveWeight(Species species ,DateTime start, DateTime end)
        {
            var vbarchart = _context.ReceivingReports
                .Where(p => p.RecTime >= start.Date && p.RecTime <= end.Date
                && p.Species == species)
                .Sum(p => p.LiveWeight);

            return vbarchart;
        }

        //from meatINspectionReport to Receiving DATE - gana
        public double AreaChartTimeSeriesRangeApproved(Species species, DateTime start, DateTime end)
        {
            var areaChart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
                .Sum(p => p.DressedWeight);

            return areaChart;
        }
        //from meatINspectionReport to Receiving DATE - gana
        public double AreaChartTimeSeriesRangeCondemned(Species species, DateTime start, DateTime end)
        {
            var areaChart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.RecTime.Date <= end.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
                .Sum(p => p.Postmortem.Weight);

            return areaChart;
        }
    }
}
