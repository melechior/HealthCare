using HealthCare.Core.Domains.DamageFiles.Dtos;
using HealthCare.Framework.Dto;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.DamagedFileDetails.Dtos;

public class DamageFileDetailDto:Dto
{
    public DamageFileDto DamageFileDto { get; set; }
    public decimal RequestedAmount { get; set; }
    public decimal FinalizeAmount { get; set; }
    public string Description { get; set; }
    public DamageFileState DamageFileState { get; set; }
    public string DamageFileStateName { get; set; }
    public DateTime DamageDate { get; set; }
    public string PersianDamageDate { get; set; }
    public string DamageItemName { get; set; }
}