using DomainLayer.Enum;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Models.ViewModels
{
	public class PostmortemViewModel
	{
		public int Id { get; set; }
		public Guid ReceivingReportId { get; set; }
		public string AnimalPart { get; set; }
		public string Cause { get; set; }
		public int Weight { get; set; }
		public int NoOfHeads { get; set; }
		public IFormFile Image1 { get; set; }
		public IFormFile Image2 { get; set; }
		public IFormFile Image3 { get; set; }
	}
}
