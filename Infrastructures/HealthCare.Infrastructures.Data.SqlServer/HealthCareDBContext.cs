using HealthCare.Core.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Contracts.Entities;
using HealthCare.Core.Domains.ContractOfPersons.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer;

public class HealthCareDbContext : DbContext
{
    public HealthCareDbContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<ContractOfPerson>();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<DamageFile> DamageFiles { get; set; }
    public DbSet<ContractOfPerson> ContractOfPeople { get; set; }
    public DbSet<DamageFileDetail> DamageFileDetails { get; set; }
    public DbSet<Personage> Personages { get; set; }
}