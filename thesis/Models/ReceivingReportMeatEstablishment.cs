namespace thesis.Models
{
    public class ReceivingReportMeatEstablishment
    {
        public int ReceivingReportId { get; set; }
        public int MeatEstablishmentId { get; set; }
        public ReceivingReport ReceivingReport { get; set; }
        public MeatEstablishment MeatEstablishment { get; set;}
    }
}
