using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetAllRequests
{
    public class GetAllRequestsQueryHandler
        : IRequestHandler<GetAllRequestsQuery, IList<Request>>
    {
        private readonly DbContext _requests;
        private readonly DbSet<Request> _requestsSet;

        public GetAllRequestsQueryHandler(DbContext requestsDbContext)
        {
            _requests = requestsDbContext;
            _requestsSet = _requests.Set<Request>();
        }

        public async Task<IList<Request>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
        {
            var a = _requestsSet.ToList();

            return await _requestsSet.ToListAsync(cancellationToken);
        }
    }
}
