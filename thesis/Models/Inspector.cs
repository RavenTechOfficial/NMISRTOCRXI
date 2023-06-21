using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;

namespace thesis.Models
{
    public class Inspector
    {
        public int Id { get; set; }
        public AccountDetails AccountDetails { get; set; }

        [ForeignKey("MeatEstablishment")]
        public int MeatEstablishmentId { get; set; }
        public MeatEstablishment MeatEstablishment { get; set;}
    }
}
