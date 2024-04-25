using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tetra.Domain;

namespace Tetra.Persistence.EntityTypeConfigurations
{
    public class UserDataConfiguration : IEntityTypeConfiguration<UserDataDomain>
    {
        public void Configure(EntityTypeBuilder<UserDataDomain> builder)
        {
            builder.ToTable("UsersData")
                .HasKey(ud => ud.Id);
        }
    }
}
