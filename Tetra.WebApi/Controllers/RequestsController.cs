using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tetra.Application.Requests.Commands.CreateRequest;
using Tetra.Application.Requests.Commands.DeleteRequest;
using Tetra.Application.Requests.Commands.UpdateRequest;
using Tetra.Application.Requests.Queries.GetAllRequests;
using Tetra.Application.Requests.Queries.GetRequest;
using Tetra.Application.Requests.Queries.GetRequestsList;
using Tetra.Domain;

namespace Tetra.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RequestsController : BaseController
    {
        [HttpGet("getAllByClientId")]
        public async Task<ActionResult<IList<RequestDomain>>> GetAllByClientId(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetRequestsByClientIdQuery
            {
                ClientId = id,
            };

            var requests = await Mediator.Send(query, cancellationToken);

            return Ok(requests);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IList<RequestDomain>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllRequestsQuery
            {
                UserId = UserId,
            };

            var requests = await Mediator.Send(query, cancellationToken);

            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDomain>> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetRequestQuery
            {
                Id = id,
            };

            var request = await Mediator.Send(query, cancellationToken);

            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRequestCommand command, CancellationToken cancellationToken)
        {
            var reqId = await Mediator.Send(command, cancellationToken);

            return Ok(reqId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRequestCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteRequestCommand
            {
                Id = id,
            };

            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
