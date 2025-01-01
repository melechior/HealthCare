using HealthCare.Core.Domains.DamageFiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.PaymentDamageFiles.Configs;

public class PaymentDamageFileConfig : IEntityTypeConfiguration<PaymentDamageFile>
{
    public void Configure(EntityTypeBuilder<PaymentDamageFile> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);
        
        builder.HasOne(f => f.DamageFileDetail)
            .WithMany(f => f.PaymentDamageFiles)
            .HasForeignKey(f => f.DamageFileDetailId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(f => f.Payment)
            .WithMany(f => f.PaymentDamageFiles)
            .HasForeignKey(f => f.PaymentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}