using System.ComponentModel.DataAnnotations.Schema;

namespace thesis.Models
{
    public class Receiving
    {
        public int Id { get; set; }
        public DateTime RecDate { get; set; }
        [ForeignKey("AccountRoles")]
        public int AccountRolesId { get; set; }
        public AccountRoles AccountRoles { get; set; }
    }
}
