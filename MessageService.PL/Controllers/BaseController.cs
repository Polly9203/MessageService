using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.PL.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; set; }

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
