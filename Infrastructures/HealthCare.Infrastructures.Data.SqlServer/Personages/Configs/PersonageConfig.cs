
using HealthCare.Core.Domains.DamageFiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.Personages.Configs;

public class PersonageConfig : IEntityTypeConfiguration<Personage>
{
    public void Configure(EntityTypeBuilder<Personage> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);

        builder.Property(p => p.NationalId).IsRequired().HasMaxLength(15);
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.MobileNumber).IsRequired(false).HasMaxLength(50);
        builder.Property(p => p.Birthdate).IsRequired(false);
        builder.Property(p => p.IsMan).IsRequired(false);
        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.BirthCertificateNumber).IsRequired(false);
        builder.Property(p => p.FatherName).IsRequired(false).HasMaxLength(50);
        builder.Property(p => p.InsuranceCoding).IsRequired(false);

        builder.HasIndex(x => x.NationalId).IsUnique();
    }
}