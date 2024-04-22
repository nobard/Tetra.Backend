using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Common.Exceptions;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequest
{
    public class GetRequestQueryHandler(IRequestsDbContext requestsDbContext)
        : IRequestHandler<GetRequestQuery, Request>
    {
        private readonly IRequestsDbContext _requestsDbContext = requestsDbContext;

        public async Task<Request> Handle(GetRequestQuery request, CancellationToken cancellationToken)
        {
            var entity = await _requestsDbContext.Requests.FirstOrDefaultAsync(req => req.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Request), request.Id);
            }

            return entity;
        }
    }
}
