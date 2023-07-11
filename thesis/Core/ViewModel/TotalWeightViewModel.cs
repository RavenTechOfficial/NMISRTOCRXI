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
        public int MonthlySuspect { get; set; }
        public int MonthlyRejected { get; set; }
        public int MonthlyCondemned { get; set; }
		//for area chart
		public int weight { get; set; }

    }
}
