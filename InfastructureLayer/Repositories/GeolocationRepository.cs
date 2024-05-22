using ServiceLayer.Services.IRepositories;
using DomainLayer.Models.ViewModels;
using InfastructureLayer.Data;
using DomainLayer.Enum;

namespace NMISRTOCXI.Repositories
{
	public class GeolocationRepository : IGeolocationRepository
	{
		
		private readonly AppDbContext _context;
		private List<GeoData> geodatas;
		public GeolocationRepository(AppDbContext context)
        {
			_context = context;
            geodatas = new List<GeoData>();
		}
		public GeolocationViewModel Getgeolocation(GeolocationViewModel geolocationData)
		{
			var meatDealers = _context.MeatDealers.Select(p => p.Address).ToList();
			var meatDestinations = _context.SummaryAndDistributionOfMICs.Select(p => p.DestinationAddress).ToList();
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
                var distinctAddresses = meatDealers.Where(address => !string.IsNullOrEmpty(address));


                foreach (var address in distinctAddresses)
                {
                    geodatas.Add(new GeoData{
                        Type = "MeatDealer",
                        Address = address
					});
                }
            }
            if (meatDestination)
            {
				var distinctAddresses = meatDestinations.Where(DestinationAddress => !string.IsNullOrEmpty(DestinationAddress));


				foreach (var address in distinctAddresses)
				{
					geodatas.Add(new GeoData
					{
						Type = "MeatDestination",
						Address = address
					});
				}
			}
            if (slaughterhouses)
            {
                var meatEst = MeatEstType(EstablishmentType.SLH);
                if (meatEst != null)
                {
                    var distinctAddresses = meatEst.Where(address => !string.IsNullOrEmpty(address));

					foreach (var address in distinctAddresses)
					{
						geodatas.Add(new GeoData
						{
							Type = "Slaughterhouse",
							Address = address
						});
					}
				}
            }

            if (poultryDressingPlants)
            {
                var meatEst = MeatEstType(EstablishmentType.PDP);
                if (meatEst != null)
                {
                    var distinctAddresses = meatEst.Where(address => !string.IsNullOrEmpty(address));

					foreach (var address in distinctAddresses)
					{
						geodatas.Add(new GeoData
						{
							Type = "PDP",
							Address = address
						});
					}
				}
            }

            if (meatcuttinplants)
            {
                var meatEst = MeatEstType(EstablishmentType.MCP);
                if (meatEst != null)
                {
                    var distinctAddresses = meatEst.Where(address => !string.IsNullOrEmpty(address));

					foreach (var address in distinctAddresses)
					{
						geodatas.Add(new GeoData
						{
							Type = "MCP",
							Address = address
						});
					}
				}
            }

            if (coldstoragewarehouse)
            {
                var meatEst = MeatEstType(EstablishmentType.CSW);
                if (meatEst != null)
                {
					var distinctAddresses = meatEst.Where(address => !string.IsNullOrEmpty(address));

					foreach (var address in distinctAddresses)
					{
						geodatas.Add(new GeoData
						{
							Type = "CSW",
							Address = address
						});
					}
				}
            }

            return new GeolocationViewModel()
			{
				GeoDatas = geodatas
			};
		}

        public List<string> MeatEstType(EstablishmentType establishmentType)
        {
            var meatEst = _context.MeatEstablishment.Where(p => p.Type == establishmentType).Select(p => p.Address).ToList();
            return meatEst;
        }
    }
}
