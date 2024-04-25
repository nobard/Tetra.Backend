using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;
using Tetra.Persistence.EntityTypeConfigurations;

namespace Tetra.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options), IRequestsDbContext, IUsersDbContext
    {
        public DbSet<RequestDomain> Requests { get; set; } = null!;
        public DbSet<UserDomain> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserDataConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
