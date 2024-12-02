using HealthCare.Core.Domains.DamagedFileDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Configs;

public class ContractConfig : IEntityTypeConfiguration<DamageFileDetail>
{

    public void Configure(EntityTypeBuilder<DamageFileDetail> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.CreationDate).IsRequired();
        builder.Property(p => p.ModifyDate).IsRequired(false);

        builder.Property(p => p.DamageFileState).IsRequired();
        builder.Property(p => p.RequestedAmount).IsRequired().HasColumnType("decimal(18,0)");
        builder.Property(p => p.DamageDate).IsRequired();
        builder.Property(p => p.SendToInsuranceDate).IsRequired(false);
        builder.Property(p => p.InsuranceReceiptNumber).IsRequired(false);
        builder.Property(p => p.Description).IsRequired(false).HasMaxLength(1500);

        builder.HasOne(f => f.DamageFile)
            .WithMany(f => f.DamageFileDetails)
            .HasForeignKey(f => f.DamageFileId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.ContractOfPerson)
            .WithMany(f => f.DamageFileDetails)
            .HasForeignKey(f => f.ContractOfPersonId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(f => f.ContractOfPerson)
            .WithMany(f => f.DamageFileDetails)
            .HasForeignKey(f => f.ContractOfPersonId)
            .IsRequired(false);
    }
}