namespace thesis.Models
{
    public class ReceivingConductOfInspection
    {
        public int ConductOfInspectionId { get; set; }
        public int ReceivingId { get; set; }
        public ConductOfInspection ConductOfInspection { get; set; }
        public Receiving Receiving { get; set; }
    }
}
