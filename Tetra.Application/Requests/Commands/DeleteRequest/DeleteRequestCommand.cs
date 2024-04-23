using MediatR;

namespace Tetra.Application.Requests.Commands.DeleteRequest
{
    public class DeleteRequestCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
