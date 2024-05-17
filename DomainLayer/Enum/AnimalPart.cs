using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enum
{
    public enum AnimalPart
    {
		[Display(Name = "N/A")]
        NA,
        Carcass,
        Lungs,
        Liver,
        Heart,
        Intestines,
        Trimmings,
        Feet,
        Kidneys,
        Spleen
    }
}
