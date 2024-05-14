using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class MTVInspection
    {
        [Key]
        public int Id { get; set; } 
        public MTVApplication MTVApplication { get; set; }
        public string Enclosed { get; set; }
        public string Insulated { get; set; }
        public string TempControlled { get; set; }
        public string PlasticCurtains { get; set; }
        public string CorrectlyInstalled { get; set; }
    }
}
