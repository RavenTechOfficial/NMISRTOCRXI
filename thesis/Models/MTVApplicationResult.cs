using System.ComponentModel.DataAnnotations;

namespace thesis.Models
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
