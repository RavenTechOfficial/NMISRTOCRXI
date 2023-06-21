using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;

namespace thesis.Models
{
    public class MeatEstablishmentRepresentative
    {
        public int Id { get; set; }
        public AccountDetails AccountDetails { get; set; }

    }
}
