namespace thesis.Models
{
    public class ReceivingMeatEstablishment
    {
        public int ReceivingId { get; set; }
        public int MeatEstablishmentId { get; set; }
        public Receiving Receiving { get; set; }
        public MeatEstablishment MeatEstablishment { get; set;}
    }
}
