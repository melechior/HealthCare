using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.ContractOfPersons.Dtos;

public class ContractOfPersonByMainPersonDto: Dto
{
    public string Firsname { get; set; }
    public string Lastname { get; set; }
    public string NationalId { get; set; }
}