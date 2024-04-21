using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;
using Tetra.Persistence.EntityTypeConfigurations;

namespace Tetra.Persistence
{
    public class RequestsDbContext(DbContextOptions<RequestsDbContext> options)
        : DbContext(options), IRequestsDbContext
    {
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
