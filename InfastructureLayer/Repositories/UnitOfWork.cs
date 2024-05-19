using InfastructureLayer.Data;
using ServiceLayer.Services.IRepositories;

namespace thesis.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context { get; set; }
        public IAccountDetailsRepository AccountDetails { get; }
        public IMeatDealersRepository MeatDealers { get; }
        public IMeatEstablishmentRepository MeatEstablishment { get; }
        public IReceivingReportRepository ReceivingReport { get; }

        public IMeatInspectionReportRepository MeatInspectionReport { get; }

        public IDashboardRepository Dashboard { get; }

        public IAnalyticsRepository Analytics { get; }

		public IUsersManangementRepository UsersManangement { get; }
		public IGeolocationRepository Geolocation { get; }

        public IResultsRepository ResultPage { get; }

		public IFeedbackRepository Feedback { get; }

        public IChroplethMapRepository ChroplethMap { get; }

        public UnitOfWork(AppDbContext context,
            IDashboardRepository dashboard,
            IAnalyticsRepository analytics,
            IUsersManangementRepository usersManangement,
            IGeolocationRepository geolocation,
            IResultsRepository resultpage,
            IFeedbackRepository feedback,
            IChroplethMapRepository chroplethMap
        ) 
        {
            _context = context;
            ReceivingReport = new ReceivingReportRepository(context);
            MeatInspectionReport = new MeatInspectionReportRepository(context);
            AccountDetails = new AccountDetailsRepository(context);
            MeatDealers = new MeatDealersRepository(context);
            MeatEstablishment = new MeatEstablishmentRepository(context);
            Dashboard = dashboard;
            Analytics = analytics;
            UsersManangement = usersManangement;
            Geolocation = geolocation;
            ResultPage = resultpage;
            Feedback = feedback;
            ChroplethMap = chroplethMap;
            
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
