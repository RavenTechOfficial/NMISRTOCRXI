using Microsoft.AspNetCore.Mvc.Rendering;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.ViewModel
{
    public class AnalyticsViewModel
    {
        
        // for area chart
        public List<double> monthlyRangeApproved { get; set; }
        public List<double> monthlyRangeCondemned { get; set; }
        public List<int> monthlyRangeOfHead { get; set; }
        public List<double> monthlyRangeOfLiveWeight { get; set; }
        public List<double> animalTypeRange { get; set; }
        public List<double> Cattle { get; set; }
        public List<double> Carabao { get; set; }
        public List<double> Swine { get; set; }
        public List<double> Goat { get; set; }
        public List<double> Chicken { get; set; }
        public List<double> Duck { get; set; }
        public List<double> Horse { get; set; }
        public List<double> Sheep { get; set; }
        public List<double> Ostrich { get; set; }
        public List<double> Crocodile { get; set; }
        public List<double> Suspect { get; set; }
        public List<double> Condemned { get; set; }
        public List<double> Pass { get; set; }
        public DateTime start { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime end { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public Species species { get; set; }
        public string timeSeries { get; set; } = "Monthly";
        

        public string[] monthAbbreviationsArray { get; set; }
    }

}
