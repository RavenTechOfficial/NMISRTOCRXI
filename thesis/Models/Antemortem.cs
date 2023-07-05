using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class Antemortem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MeatEstablishment")]
        public int MeatEstablishmentId { get; set; }
        public MeatEstablishment MeatEstablishment { get; set; }

    }
}
