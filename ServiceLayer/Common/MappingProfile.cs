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
            CreateMap<MeatDealers, MeatDealersViewModel>()
                .ForMember(dest => dest.MeatEstablishment, opt => opt.MapFrom(src => src.MeatEstablishment.Name))
                .ReverseMap();
            CreateMap<MeatDealers, UpsertMeatDealersViewModel>().ReverseMap();
        }
    }
}
