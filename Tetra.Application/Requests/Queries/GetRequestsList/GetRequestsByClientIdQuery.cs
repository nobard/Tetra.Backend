using MediatR;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequestsList
{
    public class GetRequestsByClientIdQuery : IRequest<IList<Request>>
    {
        public Guid ClientId { get; set; }
    }
}
