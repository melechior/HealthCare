using HealthCare.Core.Domains.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.Users.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);
        builder.Property(p=> p.NationalId).IsRequired().HasMaxLength(10);
        builder.Property(p => p.Username).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Password).IsRequired().HasMaxLength(200);
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(70);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(70);
        builder.Property(p => p.ImageAddress).IsRequired(false).HasMaxLength(300);
        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.Email).IsRequired(false).HasMaxLength(300);
        builder.Property(p => p.IsAdmin).IsRequired();
        builder.Property(p => p.JobPosition).IsRequired().HasMaxLength(50);

        builder.HasIndex(x => x.Username).IsUnique();

        builder.HasData(new User
        {
            Id = 1,
            NationalId="0063491702",
            Email = "alirezammn@yahoo.com",
            Username = "admin",
            Password = "J@farjo0n",
            CreationDate = DateTime.Today,
            FirstName = "علیرضا",
            LastName = "مومنی",
            ImageAddress = null,
            IsActive = true,
            IsAdmin = true,
            JobPosition = "مدیریت سیستم",
            ModifyDate = null,
        });
    }
}