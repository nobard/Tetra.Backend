using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Common.Exceptions;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequest
{
    public class GetRequestQueryHandler(IRequestsDbContext requestsDbContext)
        : IRequestHandler<GetRequestQuery, RequestDomain>
    {
        private readonly IRequestsDbContext _requestsDbContext = requestsDbContext;

        public async Task<RequestDomain> Handle(GetRequestQuery request, CancellationToken cancellationToken)
        {
            var entity = await _requestsDbContext.Requests.FirstOrDefaultAsync(req => req.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(RequestDomain), request.Id);
            }

            return entity;
        }
    }
}
