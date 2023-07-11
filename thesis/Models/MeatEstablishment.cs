using thesis.Data.Enum;

namespace thesis.Models
{
    public class MeatEstablishmentReport
    {
        public int? Id { get; set; }
        public EstablishmentType? Type { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? LicenseToOperateNumber { get; set; }
    }
}
