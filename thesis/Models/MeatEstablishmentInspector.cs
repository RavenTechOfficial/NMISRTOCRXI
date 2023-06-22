namespace thesis.Models
{
    public class MeatEstablishmentInspector
    {
        public int MeatEstablishmentId { get; set; }
        public int InspectorId { get; set; }
        public MeatEstablishment MeatEstablishment { get; set; }
        public Inspector Inspector { get; set; }
    }
}
