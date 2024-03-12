﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGo.Application.Features.Brands.Commands.Update;
using CarGo.Application.Services.Repositories;
using CarGo.Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace CarGo.Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CacheKey { get; }

        public string? CacheGroupKey => $"GetBrands";

        public bool BypassCache => false;

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
                await _brandRepository.DeleteAsync(brand);
                DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brand);
                return response;
            }
        }
    }
}
