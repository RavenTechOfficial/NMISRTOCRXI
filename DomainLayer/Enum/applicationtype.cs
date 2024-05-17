using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enum
{
	public enum ApplicationType
	{
		[Display(Name = "New Application")]
		NewApplication,
		Renewal
	}
}
