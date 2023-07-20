using System.ComponentModel.DataAnnotations;
using thesis.Data.Enum;

namespace thesis.Models
{
	public class VehicleInfo
	{
		[Key]
		public int Id { get; set; }
		public string VehicleMaker { get; set; }
		public string PlateNo { get; set; }
		public string EngineNo { get; set; }
		public string? LTOCR { get; set; }
		public string? LTOOR { get; set; }
		public EstablishmentType Est { get; set; }
		public string Destination { get; set; }
	}
}
