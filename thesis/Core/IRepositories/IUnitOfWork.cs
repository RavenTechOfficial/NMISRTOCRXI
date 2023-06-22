namespace thesis.Core.IRepositories
{
    public interface IUnitOfWork
    {
        IReceivingReportRepository ReceivingReport { get; }
        IMeatInspectionReportRepository MeatInspectionReport { get; }
    }
}
