using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;
using thesis.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;
using thesis.Areas.Identity.Data;

namespace thesis.Core.ViewModel
{
	public class MeatInspectionReportViewModel
	{
		public List<MeatInspectionReport> MeatInspectionData { get; set; }
		public List<ReceivingReport> ReceivingReportData { get; set; }

		public thesis.Models.MeatInspectionReport MeatInspectionReports { get; set; }

		public string UID { get; set; }

		public int Id { get; set; }
		public int MeatInspectionReportId { get; set; }
		public DateTime DateReceived { get; set; }
		public Species? Specie { get; set; }
		public string MeatDealer { get; set; }
		public string MeatEstablishment { get; set; }
		public DateTime DateInspected { get; set; }
		public string MeatInspector { get; set; }
		public string VerifiedBy { get; set; }


		public DateTime RepDate { get; set; }
		public int? ReceivingReportId { get; set; }
		public ReceivingReport? ReceivingReport { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? LicenseToOperateNumber { get; set; }
		public string? AccountDetailsId { get; set; }
		public AccountDetails? AccountDetails { get; set; }


	}
}