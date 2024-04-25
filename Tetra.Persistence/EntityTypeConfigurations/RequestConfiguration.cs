using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tetra.Domain;

namespace Tetra.Persistence.EntityTypeConfigurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<RequestDomain>
    {
        public void Configure(EntityTypeBuilder<RequestDomain> builder)
        {
            builder.ToTable("Requests")
                .HasKey(request => request.Id);

            builder.HasIndex(request => request.Id).IsUnique();
        }
    }
}
