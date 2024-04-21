using Microsoft.EntityFrameworkCore;
using Tetra.Domain;

namespace Tetra.Application.Interfaces
{
    public interface IRequestsDbContext
    {
        DbSet<Request> Requests { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
