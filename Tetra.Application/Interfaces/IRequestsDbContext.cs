using Microsoft.EntityFrameworkCore;
using Tetra.Domain;

namespace Tetra.Application.Interfaces
{
    public interface IRequestsDbContext : IDbContext
    {
        DbSet<RequestDomain> Requests { get; set; }
    }
}
