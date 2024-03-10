﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGo.Application.Features.Brands.Rules;
using CarGo.Application.Services.Repositories;
using CarGo.Domain.Entities;
using MediatR;

namespace CarGo.Application.Features.Brands.Commands.Create
{                                              // what this request is going to response as. 
    public class CreateBrandCommand : IRequest<CreatedBrandResponse> // it says, you are an request which is going to be used by user (The request will come from API !) 
    {
        // A createCommand will come through as a request, this request will be mapped to domain, then saved to the database.
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

                Brand brand = _mapper.Map<Brand>(request);

                brand.Id = Guid.NewGuid();
                
                await _brandRepository.AddAsync(brand);

                CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);

                return createdBrandResponse;
            }
        }
    }
}
