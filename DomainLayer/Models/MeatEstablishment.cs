using DomainLayer.Enum;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class MeatEstablishment
    {
        [Key]
        public Guid Id { get; set; }
        public EstablishmentType? EstablishmentType { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? LicenseToOperateNumber { get; set; }
        public LicenseStatus? LicenseStatus { get; set; }
        public double Longgitude { get; set; }
        public double Latitude { get; set; }
    }
}
