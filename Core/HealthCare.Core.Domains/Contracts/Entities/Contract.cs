 
using HealthCare.Core.Domains.ContractOfPersons.Entities;
using HealthCare.Framework.Domain;

namespace HealthCare.Core.Domains.Contracts.Entities;

public class Contract:BaseEntity
{
    public long? ContractInfoId { get; set; }

    public string Name { get; set; }
    public string ContractNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public long TotalPersonage { get; set; }
    public long CompletedFile { get; set; }
    public long FileNotSend { get; set; }
    public long FileSent { get; set; }
    public long FileDefect { get; set; }

    public ICollection<ContractOfPerson> ContractOfPersons { get; set; }
    //public ICollection<DamageFile> DamageFiles { get; set; }

    protected override void Validate()
    {
    }
}
