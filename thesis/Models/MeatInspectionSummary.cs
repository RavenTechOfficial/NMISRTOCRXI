using thesis.Data.Enum;

namespace thesis.Models
{
    public class MeatInspectionSummary
    {
        public int Id { get; set; } 
        public Kind Kind { get; set; }
        public int TotalInspectedInKg { get; set; }
        public int CondemnedInKg { get; set; }
        public Cause Cause { get; set; }
        public int PassedInKg { get; set; }
    }
}
