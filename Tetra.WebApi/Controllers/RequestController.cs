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
using Tetra.WebApi.Models;

namespace Tetra.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RequestController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpGet("getAllByClientId")]
        public async Task<ActionResult<IList<RequestDomain>>> GetAllByClientId(Guid id)
        {
            var query = new GetRequestsByClientIdQuery
            {
                ClientId = id,
            };

            var requests = await Mediator.Send(query);

            return Ok(requests);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IList<RequestDomain>>> GetAll()
        {
            var query = new GetAllRequestsQuery
            {
                UserId = UserId,
            };

            var requests = await Mediator.Send(query);

            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDomain>> Get(Guid id)
        {
            var query = new GetRequestQuery
            {
                Id = id,
            };

            var request = await Mediator.Send(query);

            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRequestDto createRequestDto)
        {
            var command = _mapper.Map<CreateRequestCommand>(createRequestDto);

            var reqId = await Mediator.Send(command);

            return Ok(reqId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRequestDto updateRequestDto)
        {
            var command = _mapper.Map<UpdateRequestCommand>(updateRequestDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRequestCommand
            {
                Id = id,
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
