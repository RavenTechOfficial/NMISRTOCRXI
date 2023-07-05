using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class DisapprovedApplication
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MTVInspection")]
        public int MTVInspectionId { get; set; }
        public MTVInspection MTVInspection { get; set; }
    }
}
