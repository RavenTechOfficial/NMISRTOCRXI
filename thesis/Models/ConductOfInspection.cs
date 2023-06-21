using thesis.Data.Enum;

namespace thesis.Models
{
    public class ConductOfInspection
    {
        public int Id { get; set; }
        //public Receiving Receiving { get; set; }
        public int NoOfHeads { get; set; }
        public int WeightInKg { get; set; }
        public Cause Cause { get; set; }
        public ICollection<ReceivingConductOfInspection> receivingConductOfInspections { get; set; }
    }
}
