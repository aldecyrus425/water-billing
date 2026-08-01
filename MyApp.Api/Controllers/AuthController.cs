using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Authenticate;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.isSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
