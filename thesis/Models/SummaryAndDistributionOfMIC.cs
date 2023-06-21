using thesis.Data.Enum;

namespace thesis.Models
{
    public class SummaryAndDistributionOfMIC
    {
        public int Id { get; set; }
        public int NoOfHeads { get; set; }
        public int WeightInKg { get; set; }
        public string Destination { get; set; }
        public MeatInspectionCertificateStatus MeatInspectionCertificateStatus { get; set; }

    }
}
