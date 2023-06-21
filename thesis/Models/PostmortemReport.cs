using thesis.Data.Enum;

namespace thesis.Models
{
    public class PostmortemReport
    {
        public int Id { get; set; }
        public ICollection<ReceivingPostmortemReport> receivingPostmortemReports { get; set; }
        public AnimalPart AnimalPart { get; set; }
        public Cause Cause { get; set; }
        public int WeightInKg { get; set; }
        public int NoOfHeads { get; set; }
    }
}
