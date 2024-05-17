using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enum
{
    public enum ShippingDocuments
	{
		[Display(Name = "Certificate Of OwnerShip")]
		CertificateOfOwnerShip,
		[Display(Name = "Certificate Of Transfer")]
		CertificateOfTransfer,
		[Display(Name = "Veterinary Health Certificate")]
		VeterinaryHealthCertificate,
		[Display(Name = "Shipping Permit")]
		ShippingPermit
    }
}
