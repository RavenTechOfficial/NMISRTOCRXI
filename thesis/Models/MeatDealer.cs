using System.ComponentModel.DataAnnotations.Schema;
using thesis.Areas.Identity.Data;

namespace thesis.Models
{
    public class MeatDealer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MeatEstablishmentMeatDealer> meatEstablishmentMeatDealers { get; set; }
    }
}
