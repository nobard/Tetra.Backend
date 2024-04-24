using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Guid>
    {
        private readonly DbSet<Request> _requests;
        private readonly DbContext _requestsDbContext;

        public CreateRequestCommandHandler(DbContext con)
        {
            _requests = con.Set<Request>();
            _requestsDbContext = con;
        }

        public async Task<Guid> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var newRequest = new Request
            {
                Id = Guid.NewGuid(),
                RequestNumber = _requests.Count() + 1,
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

            await _requests.AddAsync(newRequest);
            await _requestsDbContext.SaveChangesAsync(cancellationToken);

            return newRequest.Id;
        }
    }
}
