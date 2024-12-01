using System;
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.Personages.Dtos;

public class ContractNameDto: Dto
{
    public string Name { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public List<PersonageDto> Personages { get; set; }
}