using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Framework.Domain;

namespace HealthCare.Core.Domains.DamageFiles.Entities;
public class PaymentDamageFile : BaseEntity
{
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }

    public long DamageFileDetailId { get; set; }
    public DamageFileDetail DamageFileDetail { get; set; }
    
    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}