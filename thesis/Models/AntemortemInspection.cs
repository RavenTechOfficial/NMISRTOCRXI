namespace thesis.Models
{
    public class AntemortemInspection
    {
        public int Id { get; set; }
        public ConductOfInspection ConductOfInspection { get; set; }
        public PassedForSlaughter PassedForSlaughter { get; set; }
    }
}
