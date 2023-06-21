using thesis.Data.Enum;

namespace thesis.Models
{
    public class SecondaryMeatEstablishmentReport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MeatInspectionSummary MeatInspectionSummary { get; set; }
        public MeatInspectionCertUtilization MeatInspectionCertUtilization { get; set; }
        public Inspector Inspector { get; set; }
        public string NotedByPOSMSHead { get; set; }

    }
}
