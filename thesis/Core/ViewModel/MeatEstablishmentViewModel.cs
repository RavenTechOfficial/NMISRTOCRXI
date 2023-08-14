using thesis.Data.Enum;

namespace thesis.Core.ViewModel
{
    public class MeatEstablishmentViewModel
    {
        public IEnumerable<thesis.Models.MeatEstablishment> MeatEstablishments { get; set; }
        public thesis.Models.MeatEstablishment SingleMeatEstablishment { get; set; }

        public int? Id { get; set; }
        public EstablishmentType? Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? LicenseToOperateNumber { get; set; }
        public int? LicenseStatus { get; set; }
    }
}
