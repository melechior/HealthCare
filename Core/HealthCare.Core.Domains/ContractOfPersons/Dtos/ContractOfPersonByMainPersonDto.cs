using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.ContractOfPersons.Dtos;

public class ContractOfPersonByMainPersonDto: Dto
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string NationalId { get; set; }
    public string ContractName { get; set; }
}