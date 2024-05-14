using DomainLayer.Enum;

namespace DomainLayer.Models.ViewModels
{
	public class MeatEstablishmentViewModel
	{
		public IEnumerable<DomainLayer.Models.MeatEstablishment> MeatEstablishments { get; set; }
		public DomainLayer.Models.MeatEstablishment SingleMeatEstablishment { get; set; }

		public int? Id { get; set; }
		public EstablishmentType? Type { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string? LicenseToOperateNumber { get; set; }
		public int? LicenseStatus { get; set; }
		public double Long { get; set; }
		public double Lat { get; set; }
	}
}
