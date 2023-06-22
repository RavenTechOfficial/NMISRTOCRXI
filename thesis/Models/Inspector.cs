using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;

namespace thesis.Models
{
    public class Inspector
    {
        public int Id { get; set; }
        public AccountDetails AccountDetails { get; set; }
        public ICollection<MeatEstablishmentInspector> meatEstablishmentInspectors { get; set; }
    }
}
