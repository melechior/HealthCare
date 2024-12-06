using HealthCare.Framework.Dto;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.ContractOfPersons.Dtos;

public class ContractOfPersonByMainPersonDto: Dto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string NationalId { get; set; }
    public string ContractName { get; set; }
    public Relative Relative { get; set; }
    public bool? IsMan { get; set; }
}