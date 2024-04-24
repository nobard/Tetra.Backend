using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Common.Exceptions;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Commands.DeleteRequest
{
    public class DeleteRequestCommandHandler
        : IRequestHandler<DeleteRequestCommand>
    {
        private readonly DbContext _requestsDbContext;
        private readonly DbSet<Request> _requests;

        public DeleteRequestCommandHandler(DbContext requestsDbContext)
        {
            _requestsDbContext = requestsDbContext;
            _requests = requestsDbContext.Set<Request>();
        }

        public async Task Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _requests.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Request), request.Id);
            }

            _requests.Remove(entity);
            await _requestsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
