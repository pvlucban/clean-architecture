
using Clean_Architecture.Core.Application;
using Clean_Architecture.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean_Architecture.Infrastructure.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), (o => o.MigrationsHistoryTable("__EFMigrationsHistory", "Application")))

                );

        // Register repositories
        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        services.AddScoped<IAccountsRepostory, AccountsRepository>();
        return services;
    }
}
