using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class Receiving
    {
        public int Id { get; set; }
        public string RecDate { get; set; }
        public Inspector Inspector { get; set; }
        public ICollection<ReceivingConductOfInspection> receivingConductOfInspections { get; set; }
        public ICollection<ReceivingPassedForSlaughter> receivingPassedForSlaughters { get; set; }
        public ICollection<ReceivingPostmortemReport> receivingPostmortemReports { get; set; }

        //public ReceivingReport ReceivingReport { get; set; }
        //public MeatEstablishment MeatEstablishmentId { get; set; }

    }
}
