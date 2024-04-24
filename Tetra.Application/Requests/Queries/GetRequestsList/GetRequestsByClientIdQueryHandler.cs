using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequestsList
{
    public class GetRequestsByClientIdQueryHandler
        : IRequestHandler<GetRequestsByClientIdQuery, IList<Request>>
    {
        private readonly DbSet<Request> _requests;

        public GetRequestsByClientIdQueryHandler(DbContext requestsDbContext)
        {
            _requests = requestsDbContext.Set<Request>();
        }

        public async Task<IList<Request>> Handle(GetRequestsByClientIdQuery request, CancellationToken cancellationToken)
        {
            var requests = await _requests
                .Where(req => req.ClientId == request.ClientId)
                .ToListAsync();

            return requests;
        }
    }
}
