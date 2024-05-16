using System.ComponentModel.DataAnnotations;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
	public class CheckList
	{
		[Key]
		public Guid Id { get; set; }
		public string OperatorName { get; set; }
		public string EstServed { get; set; }
		public string PlateNo { get; set; }
		public string InspectorName { get; set; }
		public string InspectionDate { get; set; }
		public string InspectionTime { get; set; }
		public string Status { get; set; }
		
		
	}
}
