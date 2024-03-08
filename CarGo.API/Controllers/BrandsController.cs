using CarGo.Application.Features.Brands.Commands.Create;
using CarGo.Application.Features.Brands.Queries.GetById;
using CarGo.Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse response = await Mediator.Send(createBrandCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery query = new GetListBrandQuery(){PageRequest = pageRequest};
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery query = new GetByIdBrandQuery() { Id = id };
            GetByIdBrandResponse response = await Mediator.Send(query);

            return Ok(response);
        }
    }
}
