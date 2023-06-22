using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class MeatEstablishment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EstablishmentType establishmentType { get; set; }
        public string address { get; set; }
        public string region { get; set; }
        public int licenseToOperateNumber { get; set; }
        public MeatEstablishmentRepresentative MeatEstablishmentRepresentative { get; set; }
        public ICollection<MeatEstablishmentMeatDealer> meatEstablishmentMeatDealers { get; set; }
        public ICollection<MeatEstablishmentInspector> meatEstablishmentInspectors { get; set; }
        public ICollection<ReceivingReportMeatEstablishment> receivingReportMeatEstablishments { get; set; }
        public ICollection<ReceivingMeatEstablishment> receivingMeatEstablishments { get; set; }

    }
}
