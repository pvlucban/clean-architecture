using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean_Architecture.Infrastructure.Identity;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityStore(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure DbContext with PostgreSQL
        services.AddDbContext<UserDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), (o => o.MigrationsHistoryTable("__EFMigrationsHistory", "Identities"))));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<UserDBContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}

