using InfastructureLayer.Data;
using ServiceLayer.Services.IRepositories;

namespace thesis.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context { get; set; }
        public IAccountDetailsRepository AccountDetails { get; }
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
            IMeatInspectionReportRepository meatInspectionReport,
            IDashboardRepository dashboard,
            IAnalyticsRepository analytics,
            IUsersManangementRepository usersManangement,
            IGeolocationRepository geolocation,
            IResultsRepository resultpage,
            IFeedbackRepository feedback,
            IChroplethMapRepository chroplethMap
        ) 
        {
            ReceivingReport = new ReceivingReportRepository(context);
            AccountDetails = new AccountDetailsRepository(context);
            MeatInspectionReport = meatInspectionReport;
            Dashboard = dashboard;
            Analytics = analytics;
            UsersManangement = usersManangement;
            Geolocation = geolocation;
            ResultPage = resultpage;
            Feedback = feedback;
            ChroplethMap = chroplethMap;
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
