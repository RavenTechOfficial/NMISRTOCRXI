using System.ComponentModel.DataAnnotations;

namespace thesis.Models
{
    public class MTVDetails
    {
        [Key]
        public int Id { get; set; }
        public int ControlNo { get; set; }
        public string ApplicantType { get; set; }
        public string RegisteredOwner { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public int FaxNumber { get; set; }
        public string VehicleMaker { get; set; }
        public int PlateNo { get; set; }
        public string LTOOR { get; set; }
        public string LTOCR { get; set; }
        public string EngineNumber { get; set; }
    }
}
