using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enum
{
    public enum Issue
	{
		[Display(Name = "N/A")]
		NA,
        Suspect,
        Condemned,
        [Display(Name = "Apparently Healthy")]
        ApparentlyHealthy,
        [Display(Name = "“Animal Welfare Issue")]
        AnimalWelfareIssue,
    }
}
