using AutoMapper;
using CarGo.Application.Features.Models.Queries.GetList;
using CarGo.Application.Services.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Domain.Entities;
using Core.Persistance.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace CarGo.Application.Features.Models.Queries.GetListByDynamic
{
    public class GetListByDynamicModelQuery : IRequest<GetListResponse<GetListByDynamicModelListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        public DynamicQuery DynamicQuery { get; set; }

        public class GetListByDynamicModelQueryHandler : IRequestHandler<GetListByDynamicModelQuery, GetListResponse<GetListByDynamicModelListItemDto>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListByDynamicModelListItemDto>> Handle(GetListByDynamicModelQuery request, CancellationToken cancellationToken)
            {
                Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                    dynamic: request.DynamicQuery,
                    include: model => model.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmision),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize
                );

                var response = _mapper.Map<GetListResponse<GetListByDynamicModelListItemDto>>(models);
                return response;
            }
        }
    }
}
