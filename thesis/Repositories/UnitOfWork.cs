using thesis.Core.IRepositories;

namespace thesis.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReceivingReportRepository ReceivingReport { get; }

        public IMeatInspectionReportRepository MeatInspectionReport { get; }
        

        public UnitOfWork(
            IReceivingReportRepository receivingReport,
            IMeatInspectionReportRepository meatInspectionReport
        ) 
        {
            ReceivingReport = receivingReport;
            MeatInspectionReport = meatInspectionReport;
        }
    }
}
