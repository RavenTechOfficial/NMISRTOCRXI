using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Enum
{
    public enum EstablishmentType
    {
        [Display(Name = "Slaughter House")]
        SLH,
		[Display(Name = "Poultry Dressing Plant")]
		PDP,
		[Display(Name = "Meat Cutting Plant")]
		MCP,
		[Display(Name = "Cold Storage Warehouse")]
		CSW
    }
}
