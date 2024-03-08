using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarGo.API.Controllers
{
    public class BaseController:ControllerBase
    {
        private IMediator? _mediator;    // if there is mediatR set it, else get from IoC
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
