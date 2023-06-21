namespace thesis.Models
{
    public class PassedForSlaughter
    {
        public int Id { get; set; }
        //public Receiving Receiving { get; set; }
        public int NoOfHeads { get; set; }
        public int WeightInKg { get; set; }
        public ICollection<ReceivingPassedForSlaughter> receivingPassedForSlaughters { get; set; }
    }
}
