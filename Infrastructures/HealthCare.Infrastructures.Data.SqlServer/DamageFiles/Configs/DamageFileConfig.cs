using System;
using HealthCare.Core.Domains.DamageFiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.DamageFiles.Configs;

public class DamageFileConfig : IEntityTypeConfiguration<DamageFile>
{
    public void Configure(EntityTypeBuilder<DamageFile> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);

        builder.Property(p => p.ReceiptNumber).IsRequired(false);
        builder.Property(p => p.ReceiptDate).IsRequired();

       
    }
}