using System.ComponentModel.DataAnnotations;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
	public class checklist
	{
		[Key]
		public int Id { get; set; }
		public string operatorname { get; set; }
		public string estserved { get; set; }
		public string plateno { get; set; }
		public string inspectorname { get; set; }
		public string inspectdate { get; set; }
		public string inspecttime { get; set; }
		public string status { get; set; }
		
		
	}
}
