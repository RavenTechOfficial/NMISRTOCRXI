using Microsoft.AspNetCore.Mvc.Rendering;
using thesis.Data.Enum;
using thesis.Models;

namespace thesis.Core.ViewModel
{
    public class AnalyticsViewModel
    {
        
        // for area chart
        public List<int> monthlyRangeApproved { get; set; }
        public List<int> monthlyRangeCondemned { get; set; }
        public List<int> monthlyRangeOfHead { get; set; }
        public List<int> monthlyRangeOfLiveWeight { get; set; }
        public List<int> animalTypeRange { get; set; }
        public List<int> Cattle { get; set; }
        public List<int> Carabao { get; set; }
        public List<int> Swine { get; set; }
        public List<int> Goat { get; set; }
        public List<int> Chicken { get; set; }
        public List<int> Duck { get; set; }
        public List<int> Horse { get; set; }
        public List<int> Sheep { get; set; }
        public List<int> Ostrich { get; set; }
        public List<int> Crocodile { get; set; }
        public List<int> Suspect { get; set; }
        public List<int> Condemned { get; set; }
        public List<int> Pass { get; set; }
        

        // for horizontal bar chart 

        public string[] monthAbbreviationsArray { get; set; }
    }

}
