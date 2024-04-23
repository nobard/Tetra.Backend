﻿using MediatR;

namespace Tetra.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommand : IRequest<Guid>
    {
        public Guid ClientId { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int ContainerSize { get; set; }
        public int CargoWeight { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? Comment { get; set; }
    }
}
