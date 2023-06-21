using thesis.Data.Enum;

namespace thesis.Models
{
    public class TotalNoFitForHumanConsumption
    {
        public int Id { get; set; }
        public Species Species { get; set; }
        public int NoOfAnimals { get; set; }
        public int DressedWeightInKg { get; set; }
        public DateTime Date { get; set; }

    }
}
