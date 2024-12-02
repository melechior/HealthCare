 
using HealthCare.Core.Domains.Personages.Dtos;
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.Personages;

public class DamageFilePersonageInfoDto: Dto
{
    public DamageFilePersonageInfoDto()
    {
        Contracts = new List<ContractNameDto>();
        // SecondaryPersonage = new List<PersonageDto>();
    }
    public PersonageDto MainPersonage { get; set; }
    // public List<PersonageDto> SecondaryPersonage { get; set; }
    public List<ContractNameDto> Contracts { get; set; }
}