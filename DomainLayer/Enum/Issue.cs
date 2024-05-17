using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enum
{
    public enum Issue
	{
		[Display(Name = "N/A")]
		NA,
        Suspect,
        Condemned
    }
}
