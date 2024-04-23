using MediatR;
using Tetra.Application.Common.Exceptions;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Commands.DeleteRequest
{
    public class DeleteRequestCommandHandler(IRequestsDbContext requestsDbContext)
        : IRequestHandler<DeleteRequestCommand>
    {
        private readonly IRequestsDbContext _requestsDbContext = requestsDbContext;

        public async Task Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _requestsDbContext.Requests.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Request), request.Id);
            }

            _requestsDbContext.Requests.Remove(entity);
            await _requestsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
