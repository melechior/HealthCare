using HealthCare.Core.Domains.DamageFiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.Payments.Configs;

public class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);
        
        builder.Property(p=>p.Amount).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p=>p.ReceiptDate).IsRequired();
        builder.Property(p=>p.ReceiptNumber).IsRequired(false).HasMaxLength(100);
        builder.Property(p=>p.ShebaNumber).IsRequired(false).HasMaxLength(100);
    }
}