using System.ComponentModel.DataAnnotations;

namespace HealthCare.Infrastructures.Shared.Enums;

public enum ContractPriority
{
    /// <summary>
    /// بیمه اصلی
    /// </summary>
    [Display(Name = "بیمه اصلی")] Main = 1,
    /// <summary>
    /// بیمه کمکی
    /// </summary>
    [Display(Name = "بیمه کمکی")] Supplement=2
}   