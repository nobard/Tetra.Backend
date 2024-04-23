using MediatR;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommandHandler(IRequestsDbContext requestsDbContext)
        : IRequestHandler<CreateRequestCommand, Guid>
    {
        private readonly IRequestsDbContext _requestsDbContext = requestsDbContext;

        public async Task<Guid> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var newRequest = new Request
            {
                Id = Guid.NewGuid(),
                RequestNumber = _requestsDbContext.Requests.Count() + 1,
                Status = Domain.Enums.RequestStatus.Created,
                DepartureCity = request.DepartureCity,
                ArrivalCity = request.ArrivalCity,
                ContainerSize = request.ContainerSize,
                CargoWeight = request.CargoWeight,
                Price = request.Price,
                DepartureDate = request.DepartureDate,
                RequestCreateDate = DateTime.Now,
                Comment = request.Comment,
                ClientId = request.ClientId,
            };

            await _requestsDbContext.Requests.AddAsync(newRequest);
            await _requestsDbContext.SaveChangesAsync(cancellationToken);

            return newRequest.Id;
        }
    }
}
