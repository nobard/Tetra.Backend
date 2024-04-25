using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tetra.Domain;

namespace Tetra.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDomain>
    {
        public void Configure(EntityTypeBuilder<UserDomain> builder)
        {
            builder.ToTable("Users")
                .HasKey(user => user.Id);

            builder.HasOne(user => user.UserData)
                .WithOne(ud => ud.User).HasForeignKey<UserDataDomain>(ud => ud.UserId);

            builder.HasMany(user => user.Requests)
                .WithOne(req => req.Client)
                .HasForeignKey(req => req.ClientId);
        }
    }
}
