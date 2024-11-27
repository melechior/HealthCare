using HealthCare.Core.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructures.Data.SqlServer;

public class HealthCareDbContext : DbContext
{
    public HealthCareDbContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
    
    public DbSet<User> Users { get; set; }
}