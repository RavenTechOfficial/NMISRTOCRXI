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

		}
    }
}
