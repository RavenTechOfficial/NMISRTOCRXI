using AutoMapper;
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
                .ForMember(dest => dest.MeatDealer, opt => opt.MapFrom(src => $"{src.MeatDealers.FirstName} {src.MeatDealers.LastName}"))
                .ForMember(dest => dest.Inspector, opt => opt.MapFrom(src => $"{src.AccountDetails.firstName} {src.AccountDetails.lastName}"))
                .ForMember(dest => dest.MeatEstablishment, opt => opt.MapFrom(src => src.AccountDetails.MeatEstablishment.Name))
                .ReverseMap();
            CreateMap<ReceivingReport, CreateReceivingReportViewModel>().ReverseMap();
            CreateMap<ReceivingReport, EditReceivingReportViewModel>().ReverseMap();

        }
    }
}
