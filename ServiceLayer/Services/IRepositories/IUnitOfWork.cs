namespace ServiceLayer.Services.IRepositories
{
    public interface IUnitOfWork
    {
        Task Save();
        IReceivingReportRepository ReceivingReport { get; }
        IMeatInspectionReportRepository MeatInspectionReport { get; }
        IMeatDealersRepository MeatDealers { get; }
        IMeatEstablishmentRepository MeatEstablishment { get; }
        IAccountDetailsRepository AccountDetails { get; }
        IDashboardRepository Dashboard { get; }
        IAnalyticsRepository Analytics { get; }
        IUsersManangementRepository UsersManangement { get; }
        IGeolocationRepository Geolocation { get; }
        IResultsRepository ResultPage { get; }
        IFeedbackRepository Feedback { get; }
        IChroplethMapRepository ChroplethMap { get; }
    }
}
