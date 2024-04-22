using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Common.Exceptions;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestCommandHandler(IRequestsDbContext requestsDbContext)
        : IRequestHandler<UpdateRequestCommand>
    {
        private readonly IRequestsDbContext _requestsDbContext= requestsDbContext;

        public async Task Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _requestsDbContext.Requests.FirstOrDefaultAsync(req => req.Id == request.Id, cancellationToken);

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
