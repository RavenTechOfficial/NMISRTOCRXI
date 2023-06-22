namespace thesis.Models
{
    public class MeatEstablishmentMeatDealer
    {
        public int MeatEstablishmentId { get; set; }
        public int MeatDealerId { get; set; }
        public MeatEstablishment MeatEstablishment { get; set; }
        public MeatDealer MeatDealer { get; set; }
    }
}
