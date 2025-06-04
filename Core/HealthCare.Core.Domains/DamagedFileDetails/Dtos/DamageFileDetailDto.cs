using HealthCare.Core.Domains.DamageFiles.Dtos;
using HealthCare.Framework.Dto;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.DamagedFileDetails.Dtos;

public class DamageFileDetailDto : Dto
{
    public string InsuranceCompanyName { get; set; } = "";
    public DamageFileDto DamageFileDto { get; set; }
    public decimal RequestedAmount { get; set; }
    public decimal FinalizeAmount { get; set; }
    public string Description { get; set; }
    public DamageFileState DamageFileState { get; set; }
    public string DamageFileStateName { get; set; }
    public DateTime DamageDate { get; set; }
    public string PersianDamageDate { get; set; }
    public decimal DamageItemId { get; set; }
    public string DamageItemName { get; set; }
    public long? ContractItemId { get; set; }
    public decimal? PaymentAmount { get; set; }
    public long? PaymentId { get; set; }
    public string? ShebaNumber { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string PaymentPersianDate { get; set; } = "";
    public string SendPersianDate { get; set; } = "";
    public string Fullname { get; set; }
    public string NationalId { get; set; }
}