using System;
using HealthCare.Core.Domains.ContractOfPersons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.ContractOfPersons;

public class ContractOfPersonConfig : IEntityTypeConfiguration<ContractOfPerson>
{
    public void Configure(EntityTypeBuilder<ContractOfPerson> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);

        builder.Property(p => p.Relative).IsRequired();
        builder.Property(p => p.StartDate).IsRequired();
        builder.Property(p => p.Leader).IsRequired().HasMaxLength(100).HasDefaultValue("عمومی");

        builder.HasOne(f => f.Contract)
            .WithMany(f => f.ContractOfPersons)
            .HasForeignKey(f => f.ContractId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.Personage)
            .WithMany(f => f.ContractOfPersons)
            .HasForeignKey(f => f.PersonageId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.MainPersonage)
            .WithMany(f => f.MainContractOfPersons)
            .HasForeignKey(f => f.MainPersonageId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}