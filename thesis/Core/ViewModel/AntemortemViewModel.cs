using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.ViewModel
{
    public class ConductOfInspectionViewModel
    {
        public IEnumerable<thesis.Models.ConductOfInspection> ConductOfInspections { get; set; }
        public thesis.Models.ConductOfInspection SingleConductOfInspection { get; set; }


        public Issue Issue { get; set; }
        public int NoOfHeads { get; set; }
        public int Weight { get; set; }
        public Cause Cause { get; set; }

    }
}
