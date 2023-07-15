namespace thesis.Core.IRepositories
{
    public interface IUnitOfWork
    {
        IReceivingReportRepository ReceivingReport { get; }
        IMeatInspectionReportRepository MeatInspectionReport { get; }
        IDashboardRepository Dashboard { get; }
        IAnalyticsRepository Analytics { get; }
        IUsersManangementRepository UsersManangement { get; }
        IGeolocationRepository Geolocation { get; }
    }
}
