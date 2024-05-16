using InfastructureLayer.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public AppDbContext _context { get; set; }
		public IAccountDetailsRepository AccountDetails { get; }
		public ICheckListRepository CheckList { get; }
		public IDriverRepository Driver { get; }
		public IFeedbackRepository Feedback { get; }
		public IHelperRepository Helper { get; }
		public ILogTransactionRepository LogTransaction { get; }
		public IMeatDealerRepository MeatDealer { get; }
		public IMeatEstablishmentRepository MeatEstablishment { get; }
		public IMeatInspectionAntemortemRepository Antemortem { get; }
		public IMeatInspectionPassedForSlaughterRepository PassedForSlaughter { get; }
		public IMeatInspectionPostmortemRepository Postmortem { get; }
		public IMeatInspectionReceivingReportRepository ReceivingReport { get; }
		public IMeatInspectionReceivingRepository Receiving { get; }
		public IMeatInspectionReportRepository Report { get; }
		public IMeatInspectionSummaryAndDistributionOfMICRepository SummaryAndDistributionOfMIC { get; }
		public IMeatInspectionTotalNoFitForHumanConsumptionRepository TotalNoFitForHumanConsumptiom { get; }
		public IMTVApplicationRepository MTVApplication { get; }
		public IMTVDetailsRepository MTVDetails { get; }
		public IMTVInspectionRepository MTVInspection { get; }
		public IMTVPaymentRepository MTVPayment { get; }
		public IMTVQuizRepository MTVQuiz { get; }
		public IPostArticleRepository PostArticle { get; }
		public IQrCodeRepository QrCode { get; }
		public IResultRepository Result { get; }
		public IVehicleInfoRepository VehicleInfo { get; }
		public IAnalyticsRepository Analytics { get; }
		public IChroplethMapRepository ChroplethMap { get; }
		public IDashboardRepository Dashboard { get; }
		public IGeolocationRepository Geolocation { get; }

		public UnitOfWork(AppDbContext context)
		{
			AccountDetails = new AccountDetailsRepository(context);
			CheckList = new CheckListRepository(context);
			Driver = new DriverRepository(context);
			Feedback = new FeedbackRepository(context);
			Helper = new HelperRepository(context);
			LogTransaction = new LogTransactionRepository(context);
			MeatDealer = new MeatDealerRepository(context);
			MeatEstablishment = new MeatEstablishmentRepository(context);
			Antemortem = new MeatInspectionAntemortemRepository(context);
			PassedForSlaughter = new MeatInspectionPassedForSlaughterRepository(context);
			Postmortem = new MeatInspectionPostmortemRepository(context);
			ReceivingReport = new MeatInspectionReceivingReportRepository(context);
			Receiving = new MeatInspectionReceivingRepository(context);
			Report = new MeatInspectionReportRepository(context);
			SummaryAndDistributionOfMIC = new MeatInspectionSummaryAndDistributionOfMICRepository(context);
			TotalNoFitForHumanConsumptiom = new MeatInspectionTotalNoFitForHumanConsumptionRepository(context);
			MTVApplication = new MTVApplicationRepository(context);
			MTVDetails = new MTVDetailsRepository(context);
			MTVInspection = new MTVInspectionRepository(context);
			MTVPayment = new MTVPaymentRepository(context);
			MTVQuiz = new MTVQuizRepository(context);
			PostArticle = new PostArticleRepository(context);
			QrCode = new QrCodeRepository(context);
			Result = new ResultRepository(context);
			VehicleInfo = new VehicleInfoRepository(context);
			Analytics = new AnalyticsRepository(context);
			ChroplethMap = new ChroplethMapRepository(context);
			Dashboard = new DashboardRepository(context);
			Geolocation = new GeolocationRepository(context);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
