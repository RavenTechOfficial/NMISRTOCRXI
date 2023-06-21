using thesis.Data.Enum;

namespace thesis.Models
{
    public class MeatInspectionCertUtilization
    {
        public int Id { get; set; }
        public Kind Kind { get; set; }
        public string Destination { get; set; }
        public int VolumeInKg { get; set; }
        public int NoOfMICIssued { get; set; }
    }
}
