using thesis.Core.IRepositories;

namespace thesis.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReceivingReportRepository ReceivingReport { get; }

        public IMeatInspectionReportRepository MeatInspectionReport { get; }

        public IDashboardRepository Dashboard { get; }

        public UnitOfWork(
            IReceivingReportRepository receivingReport,
            IMeatInspectionReportRepository meatInspectionReport,
            IDashboardRepository dashboard
        ) 
        {
            ReceivingReport = receivingReport;
            MeatInspectionReport = meatInspectionReport;
            Dashboard = dashboard;
        }
    }
}
