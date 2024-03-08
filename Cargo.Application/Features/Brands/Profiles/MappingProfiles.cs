using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGo.Application.Features.Brands.Commands.Create;
using CarGo.Application.Features.Brands.Queries.GetById;
using CarGo.Application.Features.Brands.Queries.GetList;
using CarGo.Domain.Entities;
using Core.Application.Responses;
using Core.Persistance.Paging;

namespace CarGo.Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
            CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
            CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
        }
    }
}
