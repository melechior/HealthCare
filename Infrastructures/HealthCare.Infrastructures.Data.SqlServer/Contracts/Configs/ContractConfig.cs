
using HealthCare.Core.Domains.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.Contracts.Configs;
public class ContractConfig : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
        builder.Property(p => p.ContractNumber).IsRequired(false).HasMaxLength(250);
        builder.Property(p => p.StartDate).IsRequired();
        builder.Property(p => p.EndDate).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.CompletedFile).IsRequired().HasDefaultValue(0);
        builder.Property(p => p.FileDefect).IsRequired().HasDefaultValue(0);
        builder.Property(p => p.TotalPersonage).IsRequired().HasDefaultValue(0);
        builder.Property(p => p.FileNotSend).IsRequired().HasDefaultValue(0);
        builder.Property(p => p.FileSent).IsRequired().HasDefaultValue(0);
    }
}