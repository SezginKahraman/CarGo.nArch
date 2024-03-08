using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand brand = _mapper.Map<Brand>(request);
                brand.Id = Guid.NewGuid();
                
                await _brandRepository.AddAsync(brand);

                CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);

                return createdBrandResponse;
            }
        }
    }
}
