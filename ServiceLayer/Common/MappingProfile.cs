using AutoMapper;
using DomainLayer.Enum;
using DomainLayer.Models;
using DomainLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDetails, AccountDetailsViewModel>()
                .ForMember(dest => dest.MeatEstablishment, opt => opt.MapFrom(src => src.MeatEstablishment.Name))
                .ReverseMap();

            CreateMap<MeatDealers, AccountDetailsViewModel>()
                .ForMember(dest => dest.MeatEstablishment, opt => opt.MapFrom(src => src.MeatEstablishment.Name))
                .ReverseMap();
            CreateMap<MeatDealers, CreateMeatDealersViewModel>().ReverseMap();
            CreateMap<MeatDealers, EditMeatDealersViewModel>().ReverseMap();

            CreateMap<MeatEstablishment, MeatEstablishmentViewModel>().ReverseMap();
            CreateMap<MeatEstablishment, CreateMeatEstablishmentViewModel>().ReverseMap();
            CreateMap<MeatEstablishment, EditMeatEstablishmentViewModel>().ReverseMap();

            CreateMap<ReceivingReport, ReceivingReportViewModel>()
             .ForMember(dest => dest.MeatDealer, opt => 
                    opt.MapFrom(src => src.MeatDealers != null ? 
                        $"{src.MeatDealers.FirstName} {src.MeatDealers.LastName}" : null))
             .ForMember(dest => dest.MeatEstablishment, 
                    opt => opt.MapFrom(src => src.MeatDealers != null ? 
                    src.MeatDealers.MeatEstablishment.Name : null))
             .ForMember(dest => dest.Inspector, opt => 
                    opt.MapFrom(src => src.MeatInspectionReport != null && 
                                src.MeatInspectionReport.AccountDetails != null ? 
                        $"{src.MeatInspectionReport.AccountDetails.FirstName} {src.MeatInspectionReport.AccountDetails.LastName}" : null))
             .ForMember(dest => dest.MeatInspectionReport, opt => opt.MapFrom(src => src.MeatInspectionReport ?? new MeatInspectionReport()))
             .ForMember(dest => dest.Antemortems, opt => opt.MapFrom(src => src.Antemortems ?? new List<Antemortem>()))
             .ForMember(dest => dest.PassedForSlaughter, opt => opt.MapFrom(src => src.PassedForSlaughter ?? new PassedForSlaughter()))
             .ForMember(dest => dest.Postmortems, opt => opt.MapFrom(src => src.Postmortems ?? new List<Postmortem>()))
             .ForMember(dest => dest.TotalNoFitForHumanConsumption, opt => opt.MapFrom(src => src.TotalNoFitForHumanConsumption ?? new TotalNoFitForHumanConsumptions()))
             .ReverseMap();

            CreateMap<ReceivingReport, DailyInspectionViewModel>()
             .ForMember(dest => dest.MeatDealer, opt => 
                    opt.MapFrom(src => src.MeatDealers != null ? 
                        $"{src.MeatDealers.FirstName} {src.MeatDealers.LastName}" : null))
             .ForMember(dest => dest.MeatEstablishment, 
                    opt => opt.MapFrom(src => src.MeatDealers != null ? 
                    src.MeatDealers.MeatEstablishment.Name : null))
             .ForMember(dest => dest.Inspector, opt => 
                    opt.MapFrom(src => src.MeatInspectionReport != null && 
                                src.MeatInspectionReport.AccountDetails != null ? 
                        $"{src.MeatInspectionReport.AccountDetails.FirstName} {src.MeatInspectionReport.AccountDetails.LastName}" : null))
			 .ForMember(dest => dest.Frozen, opt =>
				opt.MapFrom(src => src.InspectionStatus == InspectionStatus.Frozen ?
					new List<ReceivingReportViewModel>() : null))
			.ForMember(dest => dest.Released, opt =>
				opt.MapFrom(src => src.InspectionStatus == InspectionStatus.Released ?
					new List<ReceivingReportViewModel>(): null))
			.ReverseMap();

            CreateMap<ReceivingReport, CreateReceivingReportViewModel>().ReverseMap();
            CreateMap<ReceivingReport, EditReceivingReportViewModel>().ReverseMap();

            CreateMap<Antemortem, AntemortemViewModel>()
                .ForMember(dest => dest.Issue, opt =>
                    opt.MapFrom(src => src.Issue != null ? src.Issue.ToString() : null))
                .ForMember(dest => dest.Cause, opt =>
                    opt.MapFrom(src => src.Cause != null ? src.Cause.ToString() : null))
                .ReverseMap();

            CreateMap<Postmortem, PostmortemViewModel>()
                .ForMember(dest => dest.Image1, opt => opt.Ignore()) 
                .ForMember(dest => dest.Image2, opt => opt.Ignore())
                .ForMember(dest => dest.Image3, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
