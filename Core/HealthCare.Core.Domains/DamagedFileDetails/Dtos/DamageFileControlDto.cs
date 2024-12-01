
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.DamagedFileDetails.Dtos;

public class DamageFileControlDto: Dto
{
    public long AssuranceId { get; set; }
    public long ContractId { get; set; }
    public long PersonageId { get; set; }
    public long MainPersonageId { get; set; }
    public decimal RequestedAmount { get; set; }

    public long  ContractOfPersonId { get; set; }
    public long TotalAmountUsed { get; set; }
}