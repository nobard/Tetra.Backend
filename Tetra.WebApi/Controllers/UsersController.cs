using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tetra.Application.Users.Commands.CreateUser;

namespace Tetra.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController(IMediator mediator)
        : BaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("signUp")]
        public async Task<ActionResult<CreateUserVm>> SignUp([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userVm = await _mediator.Send(command, cancellationToken);

            return Ok(userVm);
        }
    }
}
