using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;

namespace thesis.Models
{
    public class Receiving
    {
        public int Id { get; set; }
        public DateTime RecDate { get; set; }
        [ForeignKey("AccountDetails")]
        public string AccountDetailsId { get; set; }
        public AccountDetails AccountDetails { get; set; }
    }
}
