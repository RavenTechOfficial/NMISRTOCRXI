namespace thesis.Models
{
    public class MeatInspectionReport
    {
        public int Id { get; set; }
        public string RepDate { get; set; }
        public ICollection<Receiving> Receiving { get; set; }
        public TotalNoFitForHumanConsumption TotalNoFitForHumanConsumption { get; set; }
        public SummaryAndDistributionOfMIC SummaryAndDistributionOfMIC { get; set; }
        public string VerifiedByPOSMSHead { get; set; }
        //public Inspector Inspector { get; set; }
        //public MeatEstablishmentRepresentative MeatEstablishmentRepresentative { get; set; }
        //public AntemortemInspection AntemortemInspection { get; set; }
        //public PostmortemReport PostmortemInspection { get; set; }
    }
}
