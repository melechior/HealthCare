
using HealthCare.Core.Domains.Contracts.Entities;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Framework.Domain;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.ContractOfPersons.Entities;

    public class ContractOfPerson : BaseEntity
{
    public long ContractId { get; set; }
    public Contract Contract { get; set; }

    public long PersonageId { get; set; }
    public Personage Personage { get; set; }

    public long MainPersonageId { get; set; }
    public Personage MainPersonage { get; set; }

    public DateTime StartDate { get; set; }
    public Relative Relative { get; set; }
    public string Leader { get; set; }

    public ICollection<DamageFileDetail> DamageFileDetails { get; set; }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}
