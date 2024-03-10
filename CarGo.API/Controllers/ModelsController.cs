using CarGo.Application.Features.Brands.Commands.Create;
using CarGo.Application.Features.Brands.Commands.Delete;
using CarGo.Application.Features.Brands.Commands.Update;
using CarGo.Application.Features.Brands.Queries.GetById;
using CarGo.Application.Features.Brands.Queries.GetList;
using CarGo.Application.Features.Models.Queries.GetList;
using CarGo.Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace CarGo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
        //{
        //    CreatedModelResponse response = await Mediator.Send(createModelCommand);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateModelCommand updateModelCommand)
        //{
        //    UpdatedModelResponse response = await Mediator.Send(updateModelCommand);
        //    return Ok(response);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteModelCommand deleteModelCommand)
        //{
        //    DeletedModelResponse response = await Mediator.Send(deleteModelCommand);
        //    return Ok(response);
        //}

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery query = new GetListModelQuery() { PageRequest = pageRequest };
            GetListResponse<GetListModelListItemDto> response = await Mediator.Send(query);

            return Ok(response);
        }

        // dynamic implementation, 24 min
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
        {
            GetListByDynamicModelQuery query = new GetListByDynamicModelQuery() { PageRequest = pageRequest, DynamicQuery = dynamicQuery};
            GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(query);

            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] Guid id)
        //{
        //    GetByIdModelQuery query = new GetByIdModelQuery() { Id = id };
        //    GetByIdModelResponse response = await Mediator.Send(query);

        //    return Ok(response);
        //}
    }
}
