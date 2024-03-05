using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarGo.Application.Features.Brands.Commands.Create
{                                              // what this request is going to response as. 
    public class CreateBrandCommand : IRequest<CreatedBrandResponse> // it says, you are an request which is going to be used by user (The request will come from API !) 
    {
        // A createCommand will come through as a request, this request will be mapped to domain, then saved to the database.
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            public Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {


                throw new NotImplementedException();
            }
        }
    }
}
