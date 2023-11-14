using Humanizer.Localisation;
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



            for (DateTime date = startOfDate; date < currentDate; date = timeseries == "Monthly" ? date.AddMonths(1) : timeseries == "Yearly" ? date.AddYears(1) : date.AddDays(1))
            {
                var startOfPeriod = date;
                DateTime endOfPeriod;

                if (timeseries == "Monthly")
                {
                    endOfPeriod = date.AddMonths(1);
                }
                else if (timeseries == "Yearly")
                {
                    // Set the endOfPeriod to the end of the year or endDate, whichever comes first
                    //DateTime endOfYear = new DateTime(date.Year, 12, 31);
                    //endOfPeriod = endOfYear < endDate ? endOfYear : endDate;
                    endOfPeriod = date.AddYears(1);
                }
                else // Default to "Daily"
                {
                    endOfPeriod = date.AddDays(1);
                }

                //endOfPeriod = endOfPeriod > endDate ? endDate : endOfPeriod;

                var monthRangeApproved = AreaChartTimeSeriesRangeApproved(species, startOfPeriod, endOfPeriod);
                var monthRangeCondemned = AreaChartTimeSeriesRangeCondemned(species, startOfPeriod, endOfPeriod);

                var monthRangeOfHead = BarChartTimeSeriesRangeOfHead(species, startOfPeriod, endOfPeriod);
                var monthRangeOfLiveWeight = BarChartTimeSeriesRangeOfLiveWeight(species, startOfPeriod, endOfPeriod);

                var cattle = StackBarsSpeciesSeries(Species.Cattle, startOfPeriod, endOfPeriod);
                var carabao = StackBarsSpeciesSeries(Species.Carabao, startOfPeriod, endOfPeriod);
                var swine = StackBarsSpeciesSeries(Species.Swine, startOfPeriod, endOfPeriod);
                var goat = StackBarsSpeciesSeries(Species.Goat, startOfPeriod, endOfPeriod);
                var chicken = StackBarsSpeciesSeries(Species.Chicken, startOfPeriod, endOfPeriod);
                var duck = StackBarsSpeciesSeries(Species.Duck, startOfPeriod, endOfPeriod);
                var horse = StackBarsSpeciesSeries(Species.Horse, startOfPeriod, endOfPeriod);
                var sheep = StackBarsSpeciesSeries(Species.Sheep, startOfPeriod, endOfPeriod);
                var ostrich = StackBarsSpeciesSeries(Species.Ostrich, startOfPeriod, endOfPeriod);
                var crocodile = StackBarsSpeciesSeries(Species.Crocodile, startOfPeriod, endOfPeriod);

                var suspect = BarChartTimeSeriesAntemortem(species, Issue.Suspect, startOfPeriod, endOfPeriod);
                var condemned = BarChartTimeSeriesAntemortem(species, Issue.Condemned, startOfPeriod, endOfPeriod);
                var pass = BarChartTimeSeriesAntemortemPass(species, startOfPeriod, endOfPeriod);


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


                //if (timeseries == "Yearly" && date.Year == endDate.Year)
                //{
                //    break;
                //}

            }


            var currentDateFormatted = currentDate.ToString("MMM dd");

            var timeAbbreviationsList = new List<string>();
            if (timeseries == "Monthly")
            {
                int monthsApart = 12 * (endDate.Year - startDate.Year) + endDate.Month - startDate.Month;
                for (int i = 0; i < monthsApart; i++) // Loop through full months before the end date
                {
                    timeAbbreviationsList.Add(startDate.AddMonths(i).ToString("MMM yyyy")); // Use "MMM yyyy" format for month-year
                }
                // Add the end month and year if it's not the same month as the last added (in case of the current month)
                if (timeAbbreviationsList.LastOrDefault() != endDate.ToString("MMM yyyy"))
                {
                    timeAbbreviationsList.Add(endDate.ToString("MMM yyyy"));
                }
            }
            else if (timeseries == "Yearly")
            {
                int yearsApart = endDate.Year - startDate.Year;
                for (int i = 0; i < yearsApart; i++) // Loop to one less than the total to add the exact end date later
                {
                    timeAbbreviationsList.Add(new DateTime(startDate.Year + i, 1, 1).ToString("MMM yyyy"));
                }
                // Add the current date at the end to reflect the last piece of data.
                timeAbbreviationsList.Add(endDate.ToString("MMM yyyy"));
            }
            else if (timeseries == "Daily")
            {
                var totalDays = (endDate - startDate).Days;
                for (int i = 0; i <= totalDays; i++)
                {
                    timeAbbreviationsList.Add(startDate.AddDays(i).ToString("MMM dd"));
                }
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

        public double BarChartTimeSeriesRangeOfLiveWeight(Species species, DateTime start, DateTime end)
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