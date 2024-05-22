using Microsoft.EntityFrameworkCore;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;
using ServiceLayer.Services.IRepositories;

namespace NMISRTOCXI.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly AppDbContext _context;
		//area chart 
		private List<double> monthRangesApproved;
		private List<double> monthRangesCondemned;
		//horizontal bar chart
		private List<int> monthRangesOfHead;
		private List<double> monthRangesOfLiveWeight;
		//vertical bar chart
		private List<double> suspects;
		private List<double> condemneds;
		private List<double> passes;
		//piechart
		private List<double> animalType;
		//stack bars 100 chart
		private List<double> cattles;
		private List<double> carabaos;
		private List<double> swines;
		private List<double> goats;
		private List<double> chickens;
		private List<double> ducks;
		private List<double> hogs;
		private List<double> sheeps;

		private List<AnalyticViewModel> analyticObject;

		public AnalyticsRepository(AppDbContext context)
        {
            _context = context;
			this.monthRangesApproved = new List<double>();
			this.monthRangesCondemned = new List<double>();
			this.monthRangesOfHead = new List<int>();
			this.monthRangesOfLiveWeight = new List<double>();
			this.suspects = new List<double>();
			this.condemneds = new List<double>();
			this.passes = new List<double>();
			this.animalType = new List<double>();
			this.cattles = new List<double>();
			this.carabaos = new List<double>();
			this.swines = new List<double>();
			this.goats = new List<double>();
			this.chickens = new List<double>();
			this.ducks = new List<double>();
			this.hogs = new List<double>();
			this.sheeps = new List<double>();
            this.analyticObject = new List<AnalyticViewModel>();
		}

        public AnalyticsViewModel GetTotalOfMeatPerTimeSeries(string timeseries, List<Species> species, DateTime startDate, DateTime endDate)
        {


            var startOfDate = startDate;
            var currentDate = endDate;


            foreach (AnimalPart animalPart in Enum.GetValues(typeof(AnimalPart)))
            {
                var typeAnimals = PieChartAnimalTypeSeries(animalPart, startOfDate, currentDate);
                animalType.Add(typeAnimals);
            }


            // has daily
            for (DateTime date = startOfDate; date < currentDate;)
            {
                var startOfPeriod = date;
                DateTime endOfPeriod;

                if (timeseries == "Monthly")
                {
                    endOfPeriod = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
                    endOfPeriod = endOfPeriod < currentDate ? endOfPeriod : currentDate;
                }
                else if (timeseries == "Yearly")
                {
                    endOfPeriod = new DateTime(date.Year, 12, 31);
                    endOfPeriod = endOfPeriod < currentDate ? endOfPeriod : currentDate;
                }
                else // Default to "Daily"
                {
                    // Set the endOfPeriod to the end of the current day
                    endOfPeriod = date.Date.AddDays(1).AddTicks(-1);
                }

                // Consolidate data for the period from 'date' to 'endOfPeriod'

                // Move to the start of the next period
                if (timeseries == "Monthly")
                {
                    date = endOfPeriod.AddDays(1);
                }
                else if (timeseries == "Yearly")
                {
                    date = endOfPeriod.AddDays(1);
                }
                else // Default to "Daily"
                {
                    date = endOfPeriod.AddTicks(1);
                }

                //endOfPeriod = endOfPeriod > endDate ? endDate : endOfPeriod;

                var monthRangeApproved = AreaChartTimeSeriesRangeApproved(species, startOfPeriod, endOfPeriod);
                var monthRangeCondemned = AreaChartTimeSeriesRangeCondemned(species, startOfPeriod, endOfPeriod);

                monthRangesApproved.Add(monthRangeApproved);
                monthRangesCondemned.Add(monthRangeCondemned);

                analyticObject.Add(new AnalyticViewModel
                {
                    datetime = startOfPeriod.AddDays(1),
                    condemnedValue = Math.Round(monthRangeCondemned, 1),
                    approvedValue = Math.Round(monthRangeApproved, 1)
                });

            }

            // has no daily
            for (DateTime date = startOfDate; date < currentDate;)
            {
                var startOfPeriod = date;
                DateTime endOfPeriod;

                if (timeseries == "Yearly")
                {
                    

                    endOfPeriod = new DateTime(date.Year, 12, 31);
                    endOfPeriod = endOfPeriod < currentDate ? endOfPeriod : currentDate;
                }
                else
                {
                    endOfPeriod = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
                    endOfPeriod = endOfPeriod < currentDate ? endOfPeriod : currentDate;
                }

                // Consolidate data for the period from 'date' to 'endOfPeriod'

                // Move to the start of the next period
                
                date = endOfPeriod.AddDays(1);
                

                //endOfPeriod = endOfPeriod > endDate ? endDate : endOfPeriod;


                var monthRangeOfHead = BarChartTimeSeriesRangeOfHead(species, startOfPeriod, endOfPeriod);
                var monthRangeOfLiveWeight = BarChartTimeSeriesRangeOfLiveWeight(species, startOfPeriod, endOfPeriod);

                var cattle = StackBarsSpeciesSeries(Species.Cattle, startOfPeriod, endOfPeriod);
                var carabao = StackBarsSpeciesSeries(Species.Carabao, startOfPeriod, endOfPeriod);
                var swine = StackBarsSpeciesSeries(Species.Swine, startOfPeriod, endOfPeriod);
                var goat = StackBarsSpeciesSeries(Species.Goat, startOfPeriod, endOfPeriod);
                var chicken = StackBarsSpeciesSeries(Species.Chicken, startOfPeriod, endOfPeriod);
                var duck = StackBarsSpeciesSeries(Species.Duck, startOfPeriod, endOfPeriod);
                var hog = StackBarsSpeciesSeries(Species.Hog, startOfPeriod, endOfPeriod);
                var sheep = StackBarsSpeciesSeries(Species.Sheep, startOfPeriod, endOfPeriod);

                var suspect = BarChartTimeSeriesAntemortem(species, Issue.Suspect, startOfPeriod, endOfPeriod);
                var condemned = BarChartTimeSeriesAntemortem(species, Issue.Condemned, startOfPeriod, endOfPeriod);
                var pass = BarChartTimeSeriesAntemortemPass(species, startOfPeriod, endOfPeriod);



                monthRangesOfHead.Add(monthRangeOfHead);
                monthRangesOfLiveWeight.Add(monthRangeOfLiveWeight);
                cattles.Add(cattle);
                carabaos.Add(carabao);
                swines.Add(swine);
                goats.Add(goat);
                chickens.Add(chicken);
                ducks.Add(duck);
                hogs.Add(hog);
                sheeps.Add(sheep);
                suspects.Add(suspect);
                condemneds.Add(condemned);
                passes.Add(pass);

            }



            var currentDateFormatted = currentDate.ToString("MMM dd");

            var timeAbbreviationsList = new List<string>();


            
            if (timeseries == "Yearly")
            {
                int yearsApart = endDate.Year - startDate.Year;
                for (int i = 0; i < yearsApart; i++) // Loop to one less than the total to add the exact end date later
                {
                    timeAbbreviationsList.Add(new DateTime(startDate.Year + i, 1, 1).ToString("yyyy"));
                }

                timeAbbreviationsList.Add(endDate.ToString("yyyy"));
            }

            else 
            {
                int monthsApart = 12 * (endDate.Year - startDate.Year) + endDate.Month - startDate.Month;
                for (int i = 0; i < monthsApart; i++) // Loop through full months before the end date
                {
                    timeAbbreviationsList.Add(startDate.AddMonths(i).ToString("MMM yyyy")); // Use "MMM yyyy" format for month-year
                }

                if (timeAbbreviationsList.LastOrDefault() != endDate.ToString("MMM yyyy"))
                {
                    timeAbbreviationsList.Add(endDate.ToString("MMM yyyy"));
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
                monthlyRangeApproved = monthRangesApproved.Select(x => Math.Round(x, 1)).ToList(),
                monthlyRangeCondemned = monthRangesCondemned.Select(x => Math.Round(x, 1)).ToList(),
                monthlyRangeOfHead = monthRangesOfHead,
                monthlyRangeOfLiveWeight = monthRangesOfLiveWeight.Select(x => Math.Round(x, 1)).ToList(),
                animalTypeRange = animalType.Select(x => Math.Round(x, 1)).ToList(),
                Cattle = cattles.Select(x => Math.Round(x, 1)).ToList(),
                Carabao = carabaos.Select(x => Math.Round(x, 1)).ToList(),
                Swine = swines.Select(x => Math.Round(x, 1)).ToList(),
                Goat = goats.Select(x => Math.Round(x, 1)).ToList(),
                Chicken = chickens.Select(x => Math.Round(x, 1)).ToList(),
                Duck = ducks.Select(x => Math.Round(x, 1)).ToList(),
                Hog = hogs.Select(x => Math.Round(x, 1)).ToList(),
                Sheep = sheeps.Select(x => Math.Round(x, 1)).ToList(),
                Suspect = suspects.Select(x => Math.Round(x, 1)).ToList(),
                Condemned = condemneds.Select(x => Math.Round(x, 1)).ToList(),
                Pass = passes.Select(x => Math.Round(x, 1)).ToList(),
                dayMonthYearAbbreviationsArray = timeAbbreviationsArray,

                start = startDate,
                analyObjs = analyticObject
            };

        }


		//from meatINspectionReport to Receiving DATE
		public double BarChartTimeSeriesAntemortem(List<Species> speciesList, Issue issue, DateTime start, DateTime end)
		{
			double totalSum = 0;

			foreach (var species in speciesList)
			{
				//var sumForSpecies = _context.Antemortems
				//	.Include(p => p.MeatInspectionReport)
				//	.Include(p => p.MeatInspectionReport.ReceivingReport)
				//	.Where(p => p.Issue == issue
				//				&& p.MeatInspectionReport.RepDate.Date >= start.Date
				//				&& p.MeatInspectionReport.RepDate.Date <= end.Date
				//				&& p.MeatInspectionReport.ReceivingReport != null
				//				&& p.MeatInspectionReport.ReceivingReport.Species == species)
				//	.Sum(p => p.Weight);

				//totalSum += sumForSpecies;
			}

			return totalSum;
		}
		//from meatINspectionReport to Receiving DATE
		public double BarChartTimeSeriesAntemortemPass(List<Species> speciesList, DateTime start, DateTime end)
        {
            double totalSum = 0;

            foreach(var species in speciesList)
            {
				//var barchart = _context.PassedForSlaughters
				//.Include(p => p.ConductOfInspection.MeatInspectionReport.ReceivingReport)
				//.Where(p => p.ConductOfInspection.MeatInspectionReport.RepDate.Date >= start.Date
				//&& p.ConductOfInspection.MeatInspectionReport.RepDate.Date <= end.Date
				//&& p.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
				//.Sum(p => p.Weight);

    //            totalSum += barchart;
			}

            

            return totalSum;
        }


        //from meatINspectionReport to Receiving DATE
        public double StackBarsSpeciesSeries(Species species, DateTime start, DateTime end)
        {
            //var stackchart = _context.TotalNoFitForHumanConsumptions
            //    .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
            //    .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport)
            //    .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date >= start.Date
            //    && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date <= end.Date
            //    && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
            //    .Sum(p => p.DressedWeight);

            return 0;
        }
        //from meatINspectionReport to Receiving DATE
        public double PieChartAnimalTypeSeries(AnimalPart animalPart, DateTime start, DateTime end)
        {
            //var piechart = _context.Postmortems
            //    .Include(p => p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport)
            //    .Where(p => p.AnimalPart == animalPart
            //        && p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date >= start.Date
            //        && p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date <= end.Date)
            //    .Sum(p => p.Weight);

            return 0;
        }

        public int BarChartTimeSeriesRangeOfHead(List<Species> speciesList, DateTime start, DateTime end)
        {
            var totalSum = 0;


            foreach ( var species in speciesList)
            {
				var hbarchart = _context.ReceivingReports
				.Where(p => p.RecTime >= start.Date && p.RecTime <= end.Date
				&& p.Species == species)
				.Sum(p => p.NoOfHeads);

                totalSum += hbarchart;

			}

            return totalSum;
        }

        public double BarChartTimeSeriesRangeOfLiveWeight(List<Species> speciesList, DateTime start, DateTime end)
        {
            double totalSum = 0;

            foreach(var species in speciesList)
            {
				var vbarchart = _context.ReceivingReports
				.Where(p => p.RecTime >= start.Date && p.RecTime <= end.Date
				&& p.Species == species)
				.Sum(p => p.LiveWeight);

                totalSum += vbarchart;
			}
            

            return totalSum;
        }

        //from meatINspectionReport to Receiving DATE - gana
        public double AreaChartTimeSeriesRangeApproved(List<Species> speciesList, DateTime start, DateTime end)
        {
            double totalSum = 0;
            foreach(var species in speciesList)
            {
				//var areaChart = _context.TotalNoFitForHumanConsumptions
				//.Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
				//.Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date >= start.Date
				//&& p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date <= end.Date
				//&& p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
				//.Sum(p => p.DressedWeight);

    //            totalSum += areaChart;
			}
            
            return totalSum;
        }
        //from meatINspectionReport to Receiving DATE - gana
        public double AreaChartTimeSeriesRangeCondemned(List<Species> speciesList, DateTime start, DateTime end)
        {
            double totalSum = 0;

            foreach(var species in speciesList)
            {
				//var areaChart = _context.Postmortems
				//.Include(p => p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport)
				//.Where(p => p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date >= start.Date
				//&& p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.RepDate.Date <= end.Date
				//&& p.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species)
				//.Sum(p => p.Weight);

    //            totalSum += areaChart;
			}
            

            return totalSum;
        }


    }
}