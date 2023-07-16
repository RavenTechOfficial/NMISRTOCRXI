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
        public AnalyticsViewModel GetTotalOfMeatPerTimeSeries()
        {

            var currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var startDateOfWeek = DateTime.Now.AddDays(-7);
            var startDateOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var startDateOfYear = new DateTime(DateTime.Now.Year, 1, 1);
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

            for (DateTime date = startDateOfYear; date < currentDate; date = date.AddMonths(1))
            {
                var startOfMonth = date;
                var endOfMonth = date.AddMonths(1);

                var monthRangeApproved = AreaChartTimeSeriesRangeApproved(startOfMonth, endOfMonth);
                var monthRangeCondemned = AreaChartTimeSeriesRangeCondemned(startOfMonth, endOfMonth);

                var monthRangeOfHead = BarChartTimeSeriesRangeOfHead(startOfMonth, endOfMonth);
                var monthRangeOfLiveWeight = BarChartTimeSeriesRangeOfLiveWeight(startOfMonth, endOfMonth);
                
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

                var suspect = BarChartTimeSeriesAntemortem(Issue.Suspect, startOfMonth, endOfMonth);
                var condemned = BarChartTimeSeriesAntemortem(Issue.Condemned, startOfMonth, endOfMonth);
                var pass = BarChartTimeSeriesAntemortem(Issue.Pass, startOfMonth, endOfMonth);


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

            foreach (AnimalPart animalPart in Enum.GetValues(typeof(AnimalPart)))
            {
                var typeAnimals = PieChartAnimalTypeSeries(animalPart);
                animalType.Add(typeAnimals);
            }


            var monthAbbreviations = new string[]
            {
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };

            
            var monthAbbreviationsArray = monthAbbreviations.Take(currentMonth).ToArray();



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
                monthAbbreviationsArray = monthAbbreviationsArray
            };
            
        }
        public int BarChartTimeSeriesAntemortem(Issue issue, DateTime start, DateTime end)
        {
            var barchart = _context.ConductOfInspections
                .Include(p => p.Antemortem.MeatInspectionReport)
                .Where(p => p.Issue == issue
                && p.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                && p.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date)
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

        public int PieChartAnimalTypeSeries(AnimalPart animalPart)
        {
            var piechart = _context.Postmortems
                .Where(p => p.AnimalPart == animalPart)
                .Sum(p => p.Weight);

            return piechart != null ? piechart : 0;
        }

        public int BarChartTimeSeriesRangeOfHead(DateTime start, DateTime end)
        {
            var hbarchart = _context.ReceivingReports
                .Where(p => p.RecTime >= start.Date && p.RecTime <= end.Date)
                .Sum(p => p.NoOfHeads);

            return hbarchart;
        }
        public int BarChartTimeSeriesRangeOfLiveWeight(DateTime start, DateTime end)
        {
            var vbarchart = _context.ReceivingReports
                .Where(p => p.RecTime >= start.Date && p.RecTime <= end.Date)
                .Sum(p => p.LiveWeight);

            return vbarchart;
        }


        public int AreaChartTimeSeriesRangeApproved(DateTime start, DateTime end)
        {
            var areaChart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date)
                .Sum(p => p.DressedWeight);

            return areaChart;
        }

        public int AreaChartTimeSeriesRangeCondemned(DateTime start, DateTime end)
        {
            var areaChart = _context.totalNoFitForHumanConsumptions
                .Include(p => p.Postmortem)
                .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date >= start.Date
                && p.Postmortem.PassedForSlaughter.ConductOfInspection.Antemortem.MeatInspectionReport.RepDate.Date <= end.Date)
                .Sum(p => p.Postmortem.Weight);

            return areaChart;
        }
    }
}
