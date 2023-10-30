using thesis.Data.Enum;

namespace thesis.Core.ViewModel
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
	}
}
