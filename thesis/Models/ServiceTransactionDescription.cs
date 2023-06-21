using thesis.Data.Enum;

namespace thesis.Models
{
    public class ServiceTransactionDescription
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Species Species { get; set; }
        public ServiceTransactionDescriptionReport Report { get; set; }
        public Inspector Inspector { get; set; }
        public string VerifiedByPOSMSHead { get; set; }
        public string NMISRTD { get; set; }
    }
}
