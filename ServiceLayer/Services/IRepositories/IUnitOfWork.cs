namespace ServiceLayer.Services.IRepositories
{
    public interface IUnitOfWork
    {
        IReceivingReportRepository ReceivingReport { get; }
        IMeatInspectionReportRepository MeatInspectionReport { get; }
        IDashboardRepository Dashboard { get; }
        IAnalyticsRepository Analytics { get; }
        IUsersManangementRepository UsersManangement { get; }
        IGeolocationRepository Geolocation { get; }
        IResultsRepository ResultPage { get; }
        IFeedbackRepository Feedback { get; }
        IChroplethMapRepository ChroplethMap { get; }
    }
}
