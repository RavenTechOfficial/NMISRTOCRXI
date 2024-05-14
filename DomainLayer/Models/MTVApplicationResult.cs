using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class MTVApplicationResult
    {
        [Key]
        public int Id { get; set; }
        public MTVInspection MTVInspection { get; set; }
        public DateTime Received { get; set; }
        public DateTime Processed { get; set; }
    }
}
