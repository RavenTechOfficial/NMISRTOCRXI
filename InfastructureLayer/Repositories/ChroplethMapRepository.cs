using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;

namespace NMISRTOCXI.Repositories
{
    public class ChroplethMapRepository : IChroplethMapRepository
    {
        private readonly AppDbContext _context;

        public ChroplethMapRepository(AppDbContext context)
        {
            _context = context;
        }


		public ChroplethMapViewModel GetChroplethData(string display)
		{
			var isMeatSourceDisplay = display == "Meat Sources";

			var addresses = isMeatSourceDisplay ? ChroplethAdressMeatDealers() : ChroplethAdress();

			Dictionary<Species, List<double>> speciesValues = Enum.GetValues(typeof(Species))
				.Cast<Species>()
				.ToDictionary(species => species, species => new List<double>());

			foreach (var address in addresses)
			{
				var addressValues = isMeatSourceDisplay ?
					GetAllSpeciesValuesMeatDealers(address) :
					GetAllSpeciesValues(address);

				foreach (var entry in addressValues)
				{
					speciesValues[entry.Key].Add(entry.Value);
				}
			}

			return new ChroplethMapViewModel
			{
				Cattle = speciesValues[Species.Cattle],
				Carabao = speciesValues[Species.Carabao],
				Swine = speciesValues[Species.Swine],
				Goat = speciesValues[Species.Goat],
				Chicken = speciesValues[Species.Chicken],
				Duck = speciesValues[Species.Duck],
				Hog = speciesValues[Species.Hog],
				Sheep = speciesValues[Species.Sheep],
				Address = addresses.Distinct().ToList()
			};
		}

		private Dictionary<Species, double> GetAllSpeciesValues(string address)
		{
			return Enum.GetValues(typeof(Species))
				.Cast<Species>()
				.ToDictionary(species => species, species => ChroplethValue(species, address));
		}

		private Dictionary<Species, double> GetAllSpeciesValuesMeatDealers(string address)
		{
			return Enum.GetValues(typeof(Species))
				.Cast<Species>()
				.ToDictionary(species => species, species => ChroplethValueMeatDealers(species, address));
		}


		public List<string> ChroplethAdressMeatDealers()
        {
            //var addresses = _context.MeatDealers
            //                      .Select(p => p.Address)
            //                      .ToList();

			var addresses = _context.ReceivingReports
						.Select(p => p.Origin)
						.ToList();
            return addresses;
        }

        public List<string> ChroplethAdress()
		{
			var addresses = _context.SummaryAndDistributionOfMICs
								  .Select(p => p.DestinationAddress)
								  .ToList();
			return addresses;
		}

        public double ChroplethValueMeatDealers(Species species, string address)
        {
            //var stackchart = _context.TotalNoFitForHumanConsumptions
            //    .Include(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
            //    .Where(p => p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species
            //    && p.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Origin == address)
            //    .Sum(p => p.DressedWeight);

            return 0;
        }

  //      public double ChroplethValue(Species species, string address)
		//{
		//	var stackchart = _context.SummaryAndDistributionOfMICs
  //              .Include(p => p.TotalNoFitForHumanConsumption)
		//		.Where(p => p.TotalNoFitForHumanConsumption.Species == species
		//		&& p.DestinationAddress == address)
		//		.Sum(p => p.TotalNoFitForHumanConsumption.DressedWeight);

		//	return stackchart;
		//}

		public double ChroplethValue(Species species, string address)
		{
			//var stackchart = _context.SummaryAndDistributionOfMICs
			//	.Include(p => p.TotalNoFitForHumanConsumption.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport)
			//	.Where(p => p.TotalNoFitForHumanConsumption.Postmortem.PassedForSlaughter.ConductOfInspection.MeatInspectionReport.ReceivingReport.Species == species
			//	&& p.DestinationAddress == address)
			//	.Sum(p => p.TotalNoFitForHumanConsumption.DressedWeight);

			return 0;
		}
	}
}
