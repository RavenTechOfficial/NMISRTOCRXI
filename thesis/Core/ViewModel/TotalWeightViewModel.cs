using thesis.Data.Enum;

namespace thesis.Core.ViewModel
{
    public class TotalWeightViewModel
    {
        //Dashboard
        public int TotalWeight { get; set; }
        public int DailyWeight { get; set; }
        public int WeeklyWeight { get; set; }
        public int MonthlyWeight { get; set; }
        public int YearlyWeight { get; set; }
        // for bar data
        public List<int> Suspect { get; set; }
        public List<int> Condemned { get; set; }
        public List<int> Pass { get; set; }
        // for area chart
        public List<int> monthlyRangeApproved { get; set; }
		public List<int> monthlyRangeCondemned { get; set; }
		public string[] monthAbbreviationsArray { get; set; }
	}
}
