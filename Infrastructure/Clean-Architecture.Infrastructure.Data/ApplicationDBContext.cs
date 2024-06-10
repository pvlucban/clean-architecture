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
    }

    private void ConfigureAccountsEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().ToTable("Accounts", "Accounting");
        modelBuilder.Entity<Account>().Property(a => a.Id).UseIdentityAlwaysColumn();
    }
}
