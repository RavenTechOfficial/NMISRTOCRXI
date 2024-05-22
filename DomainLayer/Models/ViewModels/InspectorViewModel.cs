using DomainLayer.Enum;
using System.Web.Mvc;

namespace DomainLayer.Models.ViewModels
{
    public class InspectorViewModel
	{
		public Species SelectedSpecies { get; set; }
		public string SelectedTimeSeries { get; set; }

		public List<SelectListItem> SpeciesList { get; } = new List<SelectListItem>
		{
			new SelectListItem { Text = "Cattle", Value = "Cattle" },
			new SelectListItem { Text = "Carabao", Value = "Carabao" },
			new SelectListItem { Text = "Swine", Value = "Swine" },
			new SelectListItem { Text = "Goat", Value = "Goat" },
			new SelectListItem { Text = "Chicken", Value = "Chicken" },
			new SelectListItem { Text = "Duck", Value = "Duck" },
			new SelectListItem { Text = "Sheep", Value = "Sheep" },
			new SelectListItem { Text = "Hog", Value = "Hog" }
		};

		public List<SelectListItem> TimeSeriesList { get; } = new List<SelectListItem>
		{
			new SelectListItem { Text = "Total", Value = "Total" },
			new SelectListItem { Text = "Daily", Value = "Daily" },
			new SelectListItem { Text = "Weekly", Value = "Weekly" },
			new SelectListItem { Text = "Monthly", Value = "Monthly" },
			new SelectListItem { Text = "Yearly", Value = "Yearly" }
		};

		public IList<int> DressedWeight { get; set; }

		public IList<string> Dates { get; set; }
	}
}
