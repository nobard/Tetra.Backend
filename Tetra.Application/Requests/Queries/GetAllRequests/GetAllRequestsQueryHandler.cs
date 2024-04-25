using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetAllRequests
{
    public class GetAllRequestsQueryHandler(IRequestsDbContext requestsDbContext)
        : IRequestHandler<GetAllRequestsQuery, IList<RequestDomain>>
    {
        private readonly IRequestsDbContext _requestsDbContext = requestsDbContext;

        public async Task<IList<RequestDomain>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
        {
            var a = _requestsDbContext.Requests.ToList();

            return await _requestsDbContext.Requests.ToListAsync(cancellationToken);
        }
    }
}
