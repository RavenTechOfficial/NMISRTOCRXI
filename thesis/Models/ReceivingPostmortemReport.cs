namespace thesis.Models
{
    public class ReceivingPostmortemReport
    {
        public int ReceivingId { get; set; }
        public int PostmortemReportId { get; set; }
        public Receiving Receiving { get; set; }
        public PostmortemReport PostmortemReport { get; set; }
    }
}
