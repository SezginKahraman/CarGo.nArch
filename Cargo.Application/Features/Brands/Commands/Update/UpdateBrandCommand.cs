﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGo.Application.Services.Repositories;
using CarGo.Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace CarGo.Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CacheKey { get; }

        public string? CacheGroupKey => $"GetBrands";

        public bool BypassCache => false;

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

                // update the entity by using the request.
                brand = _mapper.Map(request, brand);
                await _brandRepository.UpdateAsync(brand);
                UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);
                return response;
            }
        }
    }
}
