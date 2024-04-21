using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tetra.Domain;

namespace Tetra.Persistence.EntityTypeConfigurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(request => request.Id);
            builder.HasIndex(request => request.Id).IsUnique();
        }
    }
}
