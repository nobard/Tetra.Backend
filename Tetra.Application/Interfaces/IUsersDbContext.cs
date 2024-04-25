using Microsoft.EntityFrameworkCore;
using Tetra.Domain;

namespace Tetra.Application.Interfaces
{
    public interface IUsersDbContext
    {
        DbSet<UserDomain> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
