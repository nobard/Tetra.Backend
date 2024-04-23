using MediatR;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetAllRequests
{
    public class GetAllRequestsQuery : IRequest<IList<Request>>
    {
        public Guid UserId { get; set; }
    }
}
