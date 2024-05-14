using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
	public class TotalWeightViewModel
	{
		//Dashboard
		public double TotalWeight { get; set; }
		public double DailyWeight { get; set; }
		public double WeeklyWeight { get; set; }
		public double MonthlyWeight { get; set; }
		public double YearlyWeight { get; set; }
		// for bar data
		public List<double> Suspect { get; set; }
		public List<double> Condemned { get; set; }
		public List<double> Pass { get; set; }
		// for area chart
		public List<double> monthlyRangeApproved { get; set; }
		public List<double> monthlyRangeCondemned { get; set; }
		public string[] monthAbbreviationsArray { get; set; }

        public List<double> Cattle { get; set; }
        public List<double> Carabao { get; set; }
        public List<double> Swine { get; set; }
        public List<double> Goat { get; set; }
        public List<double> Chicken { get; set; }
        public List<double> Duck { get; set; }
        public List<double> Hog { get; set; }
        public List<double> Sheep { get; set; }


    }
}
