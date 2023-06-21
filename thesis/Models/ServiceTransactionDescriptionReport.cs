namespace thesis.Models
{
    public class ServiceTransactionDescriptionReport
    {
        public int Id { get; set; }
        public string RepDate { get; set; }
        public int NoOfHeads { get; set; }
        public string AmFees { get; set; }
        public int VolumeInKg { get; set; }
        public string PMFees { get; set; }
        public string LGUShare { get; set; }
        public string NMISShare { get; set; }
    }
}
