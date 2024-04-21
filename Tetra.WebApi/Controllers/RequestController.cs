using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tetra.Domain;

namespace Tetra.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RequestController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IList<Request>>> GetAll()
        {
            var list = new List<Request>();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> Get(Guid id)
        {
            var request = new Request();

            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create()
        {
            return Ok(Guid.Empty);
        }

        [HttpPut]
        //UpdateRequestDto
        public async Task<IActionResult> Update([FromBody] Request request)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return NoContent();
        }
    }
}
