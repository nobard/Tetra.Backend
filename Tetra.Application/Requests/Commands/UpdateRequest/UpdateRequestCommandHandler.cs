using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Common.Exceptions;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestCommandHandler
        : IRequestHandler<UpdateRequestCommand>
    {
        private readonly DbContext _requestsDbContext;
        private readonly DbSet<Request> _requests;

        public UpdateRequestCommandHandler(DbContext requestsDbContext)
        {
            _requestsDbContext = requestsDbContext;
            _requests = requestsDbContext.Set<Request>();
        }

        public async Task Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _requests.FirstOrDefaultAsync(req => req.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(Request), request.Id);
            }

            entity.Status = request.Status;
            entity.DepartureDate = request.DepartureDate;
            entity.ArrivalCity = request.ArrivalCity;
            entity.ContainerSize = request.ContainerSize;
            entity.CargoWeight = request.CargoWeight;
            entity.Price = request.Price;
            entity.DepartureDate = request.DepartureDate;
            entity.Comment = request.Comment;

            await _requestsDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
