using MediatR;
using Tetra.Domain.Enums;

namespace Tetra.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestCommand : IRequest
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int ContainerSize { get; set; }
        public int CargoWeight { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? Comment { get; set; }
    }
}
