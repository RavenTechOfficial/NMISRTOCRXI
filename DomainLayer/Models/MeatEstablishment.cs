using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class MeatEstablishment
    {
        public Guid? Id { get; set; }
        public EstablishmentType? Type { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? LicenseToOperateNumber { get; set; }
        public LicenseStatus? LicenseStatus { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
    }
}
