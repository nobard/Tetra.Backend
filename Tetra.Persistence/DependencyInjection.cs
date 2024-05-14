using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tetra.Application.Interfaces;
using Tetra.Persistence.Security;

namespace Tetra.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IRequestsDbContext>(provider
               => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IUsersDbContext>(provider
               => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IDbContext>(provider
               => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
