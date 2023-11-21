namespace thesis.Core.ViewModel
{
    public class ChroplethMapViewModel
    {
        public List<double> Cattle { get; set; }
        public List<double> Carabao { get; set; }
        public List<double> Swine { get; set; }
        public List<double> Goat { get; set; }
        public List<double> Chicken { get; set; }
        public List<double> Duck { get; set; }
        public List<double> Hog { get; set; }
        public List<double> Sheep { get; set; }
        public List<string> Address { get; set; }
        public bool MeatSourcesBool { get; set; }
        public bool MeatDestinationBool { get; set; }
    }
}
