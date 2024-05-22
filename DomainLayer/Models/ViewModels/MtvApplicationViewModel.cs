using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Models.ViewModels
{
	public class MtvApplicationViewModel
	{
		//Mtv application
		public ApplicationType applicationtype { get; set; }
		public string AccreditionNo { get; set; }
		public string OwnerFname { get; set; }
		public string OwnerMname { get; set; }
		public string OwnerLname { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string TelNo { get; set; }
		public string FaxNo { get; set; }
		public string Status { get;set; }


		//Vehicle Info
		
		public string VehicleMaker { get; set; }
		public string PlateNo { get; set; }
		public string EngineNo { get; set; }
		public IFormFile LTOCR { get; set; }
		public IFormFile LTOOR { get; set; }
		public EstablishmentType Est { get; set; }
		public string Destination { get; set; }

		//Helper
		
		public string HelperFname { get; set; }
		public string HelperMname { get; set; }
		public string HelperLname { get; set; }
		public string HelperAddress { get; set; }
		public string HelperEmail { get; set; }
		public string HelperTelNo { get; set; }
		public DateTime Helperbirthdate { get; set; }

		//Driver
		
		public string DriverFname { get; set; }
		public string DriverMname { get; set; }
		public string DriverLname { get; set; }
		public IFormFile LicenseFront { get; set; }
		public IFormFile LicenseBack { get; set; }
		public string DriverAddress { get; set; }
		public string DriverEmail { get; set; }
		public string DriverTelNo { get; set; }
		public Gender Gender { get; set; }
		public DateTime Driverbirthdate { get; set; }
	}
}
