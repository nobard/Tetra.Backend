using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommandHandler(IRequestsDbContext requestsDbContext, IUsersDbContext usersDbContext)
        : IRequestHandler<CreateRequestCommand, Guid>
    {
        private readonly IRequestsDbContext _requestsDbContext = requestsDbContext;
        private readonly IUsersDbContext _usersDbContext = usersDbContext;

        public async Task<Guid> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var client = await _usersDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.ClientId, cancellationToken);

            //TODO кастомная ошибка
            if (client is null)
            {
                throw new Exception($"Пользователя (id: {request.ClientId}) не существует.");
            }

            var newRequest = new RequestDomain
            {
                Id = Guid.NewGuid(),
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
