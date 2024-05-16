using DomainLayer.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class MTVInspection
    {
        [Key]
        public Guid Id { get; set; }
		[ForeignKey("MTVApplication")]
		public Guid? MTVApplicationId { get; set; }
		public virtual MTVApplication MTVApplication { get; set; }
        public bool Enclosed { get; set; }
        public bool Insulated { get; set; }
        public bool TempControlled { get; set; }
        public bool PlasticCurtains { get; set; }
        public bool CorrectlyInstalled { get; set; }
        public InspectionStatus InspectionStatus { get; set; }
	}
}
