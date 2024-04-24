using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Common.Exceptions;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Queries.GetRequest
{
    public class GetRequestQueryHandler : IRequestHandler<GetRequestQuery, Request>
    {
        private readonly DbSet<Request> _requests;

        public GetRequestQueryHandler(DbContext requestsDbContext)
        {
            _requests = requestsDbContext.Set<Request>();
        }

        public async Task<Request> Handle(GetRequestQuery request, CancellationToken cancellationToken)
        {
            var entity = await _requests.FirstOrDefaultAsync(req => req.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Request), request.Id);
            }

            return entity;
        }
    }
}
