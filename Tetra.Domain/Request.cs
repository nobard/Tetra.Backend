using Tetra.Domain.Enums;

namespace Tetra.Domain
{
    public class Request
    {
        public Guid Id { get; set; }
        public int RequestNumber { get; set; }
        public RequestStatus Status { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int ContainerSize { get; set; }
        public int CargoWeight { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime RequestCreateDate { get; set; }
        public string? Comment { get; set; }
        public Guid ClientId { get; set; }
    }
}
