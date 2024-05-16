using InfastructureLayer.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
	public interface IUnitOfWork
	{
		IAccountDetailsRepository AccountDetails { get; }
		IAnalyticsRepository Analytics { get; }
		IMeatInspectionAntemortemRepository Antemortem { get; }
		ICheckListRepository CheckList { get; }
		IChroplethMapRepository ChroplethMap { get; }
		IDashboardRepository Dashboard { get; }
		IDriverRepository Driver { get; }
		IFeedbackRepository Feedback { get; }
		IGeolocationRepository Geolocation { get; }
		IHelperRepository Helper { get; }
		ILogTransactionRepository LogTransaction { get; }
		IMeatDealerRepository MeatDealer { get; }
		IMeatEstablishmentRepository MeatEstablishment { get; }
		IMTVApplicationRepository MTVApplication { get; }
		IMTVDetailsRepository MTVDetails { get; }
		IMTVInspectionRepository MTVInspection { get; }
		IMTVPaymentRepository MTVPayment { get; }
		IMTVQuizRepository MTVQuiz { get; }
		IMeatInspectionPassedForSlaughterRepository PassedForSlaughter { get; }
		IPostArticleRepository PostArticle { get; }
		IMeatInspectionPostmortemRepository Postmortem { get; }
		IQrCodeRepository QrCode { get; }
		IMeatInspectionReceivingRepository Receiving { get; }
		IMeatInspectionReceivingReportRepository ReceivingReport { get; }
		IMeatInspectionReportRepository Report { get; }
		IResultRepository Result { get; }
		IMeatInspectionSummaryAndDistributionOfMICRepository SummaryAndDistributionOfMIC { get; }
		IMeatInspectionTotalNoFitForHumanConsumptionRepository TotalNoFitForHumanConsumptiom { get; }
		IVehicleInfoRepository VehicleInfo { get; }

		void Save();
	}
}