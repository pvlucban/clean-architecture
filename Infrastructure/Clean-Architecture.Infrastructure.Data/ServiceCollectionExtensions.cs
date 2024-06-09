
using Clean_Architecture.Core.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean_Architecture.Infrastructure.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure DbContext with PostgreSQL
        // services.AddDbContext<ApplicationDBContext>(options =>
        //     options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), (o => o.MigrationsHistoryTable("__EFMigrationsHistory", "Application")))

                );

        // Register repositories
        services.AddScoped<ICompaniesRepository, CompaniesRepository>();

        return services;
    }
}
