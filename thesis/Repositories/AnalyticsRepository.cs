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
            var monthRangesApproved = new List<int>();
            var monthRangesCondemned = new List<int>();
            //horizontal bar chart
            var monthRangesOfHead = new List<int>();
            var monthRangesOfLiveWeight = new List<int>();
            //vertical bar chart
            var suspects = new List<int>();
            var condemneds = new List<int>();
            var passes = new List<int>();
            //piechart
            var animalType = new List<int>();
            //stack bars 100 chart
            var cattles = new List<int>();
            var carabaos = new List<int>();
            var swines = new List<int>();
            var goats = new List<int>();
            var chickens = new List<int>();
            var ducks = new List<int>();
            var horses = new List<int>();
            var sheeps = new List<int>();
            var ostrichs = new List<int>();
            var crocodiles = new List<int>();



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
                var pass = BarChartTimeSeriesAntemortem(species, Issue.Pass, startOfMonth, endOfMonth);


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
        public int BarChartTimeSeriesAntemortem(Species species, Issue issue, DateTime start, DateTime end)
        {
            var barchart = _context.ConductOfInspections
            .Include(p => p.Antemortem.MeatInspectionReport)
            .Include(p => p.Antemortem.MeatInspectionReport.ReceivingReport)
            .Where(p => p.Issue == issue
                        && p.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                        && p.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date
                        && p.Antemortem.MeatInspectionReport.ReceivingReport != null
                        && p.Antemortem.MeatInspectionReport.ReceivingReport.Species == species)
            .Sum(p => p.NoOfHeads);


            return barchart;
        }


        public int StackBarsSpeciesSeries(Species species, DateTime start, DateTime end)
        {
            var stackchart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date
                && p.Species == species)
                .Sum(p => p.DressedWeight);

            return stackchart;
        }

        public int PieChartAnimalTypeSeries(AnimalPart animalPart, DateTime start, DateTime end)
        {
            var piechart = _context.Postmortems
                .Include(p => p.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport)
                .Where(p => p.AnimalPart == animalPart
                    && p.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                    && p.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date)
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
        public int BarChartTimeSeriesRangeOfLiveWeight(Species species ,DateTime start, DateTime end)
        {
            var vbarchart = _context.ReceivingReports
                .Where(p => p.RecTime >= start.Date && p.RecTime <= end.Date
                && p.Species == species)
                .Sum(p => p.LiveWeight);

            return vbarchart;
        }


        public int AreaChartTimeSeriesRangeApproved(Species species, DateTime start, DateTime end)
        {
            var areaChart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date
                && p.Species == species)
                .Sum(p => p.DressedWeight);

            return areaChart;
        }

        public int AreaChartTimeSeriesRangeCondemned(Species species, DateTime start, DateTime end)
        {
            var areaChart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date
                && p.Species == species)
                .Sum(p => p.Postmortem.Weight);

            return areaChart;
        }
    }
}
