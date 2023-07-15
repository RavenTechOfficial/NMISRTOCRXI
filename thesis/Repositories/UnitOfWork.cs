using thesis.Core.IRepositories;

namespace thesis.Repositories
{
	public class UnitOfWork : IUnitOfWork
    {
        public IReceivingReportRepository ReceivingReport { get; }

        public IMeatInspectionReportRepository MeatInspectionReport { get; }

        public IDashboardRepository Dashboard { get; }

        public IAnalyticsRepository Analytics { get; }

		public IUsersManangementRepository UsersManangement { get; }
		public IGeolocationRepository Geolocation { get; }

		public UnitOfWork(
            IReceivingReportRepository receivingReport,
            IMeatInspectionReportRepository meatInspectionReport,
            IDashboardRepository dashboard,
            IAnalyticsRepository analytics,
            IUsersManangementRepository usersManangement,
            IGeolocationRepository geolocation
        ) 
        {
            ReceivingReport = receivingReport;
            MeatInspectionReport = meatInspectionReport;
            Dashboard = dashboard;
            Analytics = analytics;
            UsersManangement = usersManangement;
            Geolocation = geolocation;
        }
    }
}
