using System;
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.Personages.Dtos;

public class PersonageProfileDto :Dto
{
    public string ContractName { get; set; }
    public string MainParentName { get; set; }
    public string MainNationalId { get; set; }
    public string ShebaNumber { get; set; }
}