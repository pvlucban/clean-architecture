using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Infrastructure.Identity;

public class UserDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public UserDBContext(DbContextOptions<UserDBContext> options)
           : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("Identities");
        // Configure entity relationships and properties
    }
}