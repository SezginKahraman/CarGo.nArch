using CarGo.Application.Features.Brands.Commands.Create;
using CarGo.Application.Features.Brands.Commands.Delete;
using CarGo.Application.Features.Brands.Commands.Update;
using CarGo.Application.Features.Brands.Queries.GetById;
using CarGo.Application.Features.Brands.Queries.GetList;
using CarGo.Domain.Entities;
using Core.Application.Responses;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGo.Application.Features.Models.Queries.GetList;
using CarGo.Application.Features.Models.Queries.GetListByDynamic;

namespace CarGo.Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Model, GetByIdModelResponse>().ReverseMap();
            CreateMap<Model, GetListModelListItemDto>()
                .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
                .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
                .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmision.Name))
                .ReverseMap();
            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

            CreateMap<Model, GetListByDynamicModelListItemDto>()
                .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
                .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
                .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmision.Name))
                .ReverseMap();
            CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
        }
    }
}
