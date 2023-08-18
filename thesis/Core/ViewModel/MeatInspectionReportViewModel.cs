using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;
using thesis.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thesis.Core.ViewModel;

namespace thesis.Core.ViewModel
{
    public class MeatInspectionReportViewModel
    {
        //public DateTime InspectDate { get; set; } = DateTime.Now;
        //public string? VerifiedByPOSMSHead { get; set; }
        //public int ReceivingReportId { get; set; }
        //public DateTime ReceivedDate { get; set; }
        //public Species Species { get; set; }
        //public int NoOfHeads { get; set; }
        //public int MeatDealersId { get; set; }
        //Receiving Reports
        public DateTime RecTime { get; set; }
        public Species? Species { get; set; }
        public int? LiveWeight { get; set; }
        public string MeatDealer { get; set; }
        //Conduct of Inspection
        public Issue Issue { get; set; }
        public int NoOfHeads { get; set; }
        public int Weight { get; set; }
        public Cause Cause { get; set; }
        //Passed for Slaughter
        public int NoOfHeadsPassed { get; set; }
        public double WeightPassed { get; set; }
        //Postmortem
        public AnimalPart AnimalPart { get; set; }
        public Cause PostmortemCause { get; set; }
        public int PostmortemWeight { get; set; }
        public int PostmortemNoOfHeads { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        //Fit for Human Consumption
        public Species FitforConSpecies { get; set; }
        public int FitforConNoOfHeads { get; set; }
        public int DressedWeight { get; set; }
        //Distribution of MIC
        public string DestinationName { get; set; }
        public string DestinationAddress { get; set; }
        public CertificateStatus CertificateStatus { get; set; }
        //uid
        public string uid { get; set; }
    }
}
