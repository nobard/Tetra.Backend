using MediatR;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequest
{
    public class GetRequestQuery : IRequest<Request>
    {
        public Guid Id { get; set; }
    }
}
