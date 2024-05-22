using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enum
{
    public enum Cause
	{
		[Display(Name = "N/A")]
		NA,
        Actinobacillosis,
        Actinomycosis,
        Anaplasmosis,
        Anthrax,
        Aflatoxicosis,
        Ascariasis,
        AtrophicRhinitis,
        Others
    }
}
