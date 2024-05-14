using Microsoft.EntityFrameworkCore;
using Tetra.Domain;

namespace Tetra.Application.Interfaces
{
    public interface IUsersDbContext : IDbContext
    {
        DbSet<UserDomain> Users { get; set; }
    }
}
