using thesis.Core.IRepositories;
using thesis.Core.ViewModel;
using thesis.Data;
using thesis.Data.Enum;

namespace thesis.Repositories
{
	public class GeolocationRepository : IGeolocationRepository
	{
		private readonly thesisContext _context;

		public GeolocationRepository(thesisContext context)
        {
			_context = context;
		}
		public GeolocationViewModel Getgeolocation(GeolocationViewModel geolocationData)
		{
			var meatDealers = _context.MeatDealers.Select(p => p.Address).ToList();
			var summary = _context.SummaryAndDistributionOfMICs
				.Select(p => p.DestinationAddress)
				.ToList();

			bool slaughterhouses = geolocationData.SlaughterHouses;
			bool poultryDressingPlants = geolocationData.PoultryDressingPlants;
			bool meatcuttinplants = geolocationData.MeatCuttingPlants;
			bool coldstoragewarehouse = geolocationData.ColdStorageWarehouse;
			bool meatDealer = geolocationData.MeatDealers;
			bool meatDestination = geolocationData.MeatDestinations;
			bool nmisrtocxi = geolocationData.NMISRTOCXI;

			var addressList = new List<string>();
			var colors = new List<string>();
			if (meatDealer)
			{
				addressList.AddRange(meatDealers.Where(address => !string.IsNullOrEmpty(address)));
				if (meatDealers != null)
				{
					colors.AddRange(Enumerable.Repeat("red", meatDealers.Count));
				}
			}
			if (meatDestination)
			{
				addressList.AddRange(summary.Where(address => !string.IsNullOrEmpty(address)));
				if (summary != null)
				{
					colors.AddRange(Enumerable.Repeat("blue", summary.Count));
				}
			}
			if (slaughterhouses)
			{
				var meatEst = MeatEstType(EstablishmentType.SLH);
				if (meatEst != null)
				{
					addressList.AddRange(meatEst.Where(address => !string.IsNullOrEmpty(address)));
					colors.AddRange(Enumerable.Repeat("green", meatEst.Count));
				}
			}
			if (poultryDressingPlants)
			{
				var meatEst = MeatEstType(EstablishmentType.PDP);
				if (meatEst != null)
				{
					addressList.AddRange(meatEst.Where(address => !string.IsNullOrEmpty(address)));
					colors.AddRange(Enumerable.Repeat("blue", meatEst.Count));
				}
			}
			if (meatcuttinplants)
			{
				var meatEst = MeatEstType(EstablishmentType.MCP);
				if (meatEst != null)
				{
					addressList.AddRange(meatEst.Where(address => !string.IsNullOrEmpty(address)));
					colors.AddRange(Enumerable.Repeat("white", meatEst.Count));
				}
			}
			if (coldstoragewarehouse)
			{
				var meatEst = MeatEstType(EstablishmentType.CSW);
				if (meatEst != null)
				{
					addressList.AddRange(meatEst.Where(address => !string.IsNullOrEmpty(address)));
					colors.AddRange(Enumerable.Repeat("black", meatEst.Count));
				}
			}

			return new GeolocationViewModel()
			{
				address = addressList.ToArray(),
				colors = colors.ToArray(),
			};
		}

		public List<string> MeatEstType(EstablishmentType establishmentType)
		{
			var meatEst = _context.MeatEstablishment.Where(p => p.Type == establishmentType).Select(p => p.Address).ToList();
			return meatEst;
		}
	}
}
