using Tetra.Domain.Enums;

namespace Tetra.Domain
{
    public class RequestDomain
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }
        public string DepartureCity { get; set; } = null!;
        public string ArrivalCity { get; set; } = null!;
        public int ContainerSize { get; set; }
        public int CargoWeight { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime RequestCreateDate { get; set; }
        public string? Comment { get; set; }
        public Guid ClientId { get; set; }
        public UserDomain Client { get; set; }
    }
}
