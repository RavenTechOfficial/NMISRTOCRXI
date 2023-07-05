using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using thesis.Data.Enum;

namespace thesis.Models
{
    public class totalNoFitForHumanConsumptions
    {
        [Key]
        public int Id { get; set; }
        public Species Species { get; set; }
        public int NoOfHeads { get; set; }
        public int DressedWeight { get; set; }
        [ForeignKey("PostmortemId")]
        public int PostmortemId { get; set; }
        public Postmortem Postmortem { get; set; }

    }
}
