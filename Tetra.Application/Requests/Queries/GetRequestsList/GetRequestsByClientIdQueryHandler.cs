using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequestsList
{
    public class GetRequestsByClientIdQueryHandler(IRequestsDbContext requestsDbContext)
        : IRequestHandler<GetRequestsByClientIdQuery, IList<RequestDomain>>
    {
        private readonly IRequestsDbContext _requestsDbContext = requestsDbContext;

        public async Task<IList<RequestDomain>> Handle(GetRequestsByClientIdQuery request, CancellationToken cancellationToken)
        {
            var requests = await _requestsDbContext.Requests
                .Where(req => req.ClientId == request.ClientId)
                .ToListAsync();

            return requests;
        }
    }
}
