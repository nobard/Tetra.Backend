using MediatR;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequestsList
{
    public class GetRequestsByClientIdQuery : IRequest<IList<RequestDomain>>
    {
        public Guid ClientId { get; set; }
    }
}
