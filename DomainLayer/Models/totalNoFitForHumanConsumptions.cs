using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Enum;

namespace DomainLayer.Models
{
    public class totalNoFitForHumanConsumptions
    {
        [Key]
        public int Id { get; set; }
        public Species Species { get; set; }
        public int NoOfHeads { get; set; }
        public double DressedWeight { get; set; }
        [ForeignKey("PostmortemId")]
        public int PostmortemId { get; set; }
        public Postmortem? Postmortem { get; set; }

    }
}
