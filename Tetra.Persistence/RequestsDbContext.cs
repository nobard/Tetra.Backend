using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;
using Tetra.Persistence.EntityTypeConfigurations;

namespace Tetra.Persistence
{
    public class RequestsDbContext(DbContextOptions<RequestsDbContext> options)
        : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
