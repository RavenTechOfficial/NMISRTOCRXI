using thesis.Data.Enum;

namespace thesis.Core.ViewModel
{
    public class TotalWeightViewModel
    {
        public int TotalWeight { get; set; }
        public Species SelectedSpecies { get; set; }
        public int DailyWeight { get; set; }
        public int WeeklyWeight { get; set; }
        public int MonthlyWeight { get; set; }
        public int YearlyWeight { get; set; }
    }
}
