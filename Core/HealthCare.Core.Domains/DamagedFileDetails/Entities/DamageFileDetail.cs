using HealthCare.Core.Domains.ContractOfPersons.Entities;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Users.Entities;
using HealthCare.Framework.Domain;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.DamagedFileDetails;

public class DamageFileDetail : BaseEntity
{
    public long DamageFileId { get; set; }
    public DamageFile DamageFile { get; set; }

    public long ContractOfPersonId { get; set; }
    public ContractOfPerson ContractOfPerson { get; set; }
    public string DamageItem { get; set; }
    public DateTime? SendToInsuranceDate { get; set; }
    public string InsuranceReceiptNumber { get; set; }
    public DamageFileState DamageFileState { get; set; }
    public decimal RequestedAmount { get; set; }
    public DateTime DamageDate { get; set; }
    public string? Description { get; set; }
    
    public ICollection<PaymentDamageFile> PaymentDamageFiles { get; set; }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}