using Clean_Architecture.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Clean_Architecture.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Application");
        ConfigureCompaniesEntity(modelBuilder);
        ConfigureAccountsEntity(modelBuilder);
    }

    private void ConfigureCompaniesEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().ToTable("Companies", "Common");
        modelBuilder.Entity<Company>().Property(a => a.Name).HasMaxLength(200);
        modelBuilder.Entity<Company>().Property(a => a.Id).HasValueGenerator<GuidValueGenerator>();
        ConfigureWithAuditBaseEntity<Company>(modelBuilder);
    }

    private void ConfigureAccountsEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().ToTable("Accounts", "Accounting");
        modelBuilder.Entity<Account>().Property(a => a.Id).UseIdentityAlwaysColumn();
        ConfigureWithAuditBaseEntity<Account>(modelBuilder);
    }

    private void ConfigureWithAuditBaseEntity<T>(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity(typeof(T)).Property("CreatedBy").HasMaxLength(100);
        modelBuilder.Entity(typeof(T)).Property("UpdatedBy").HasMaxLength(100);
    }
}
