using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class Postmortem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PassedForSlaughter")]
        public int PassedForSlaughterId { get; set; }
        public PassedForSlaughter PassedForSlaughter { get; set; }
        public AnimalPart AnimalPart { get; set; }
        public Cause Cause { get; set; }
        public int Weight { get; set; }
        public int NoOfHeads { get; set; }
        public string? Image1 { get; set; } // Nullable string property
        public string? Image2 { get; set; } // Nullable string property
        public string? Image3 { get; set; } // Nullable string property
    }
}
