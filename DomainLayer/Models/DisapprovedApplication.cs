using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class DisapprovedApplication
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MTVInspection")]
        public Guid MTVInspectionId { get; set; }
        public virtual MTVInspection MTVInspection { get; set; }
    }
}
