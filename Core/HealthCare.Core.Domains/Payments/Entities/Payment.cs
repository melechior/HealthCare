using HealthCare.Framework.Domain;

namespace HealthCare.Core.Domains.DamageFiles.Entities;
public class Payment : BaseEntity
{
    public string ReceiptNumber { get; set; }
    public DateTime ReceiptDate { get; set; }
    public decimal Amount { get; set; }
    public string ShebaNumber { get; set; }

    public ICollection<PaymentDamageFile> PaymentDamageFiles { get; set; }
    
    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}