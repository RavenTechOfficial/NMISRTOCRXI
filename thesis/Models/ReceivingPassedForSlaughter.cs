namespace thesis.Models
{
    public class ReceivingPassedForSlaughter
    {
        public int PassedForSlaughterId { get; set; }
        public int ReceivingId { get; set; }
        public Receiving Receiving { get; set; }
        public PassedForSlaughter PassedForSlaughter { get; set; }
    }
}
