using Microsoft.EntityFrameworkCore;
using Tetra.Domain;

namespace Tetra.Application.Interfaces
{
    public interface IRequestsDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
