using System.ComponentModel.DataAnnotations;

namespace HealthCare.Infrastructures.Shared.Enums;

public enum DamageFileState
{
    /// <summary>
    /// ثبت اولیه
    /// </summary>
    [Display(Name = "در حال بررسی")] InitialRegistration = 1,

    /// <summary>
    /// ثبت اسناد
    /// </summary>
    [Display(Name = "در حال بررسی")] RegistrationDocuments = 2,

    /// <summary>
    /// آماده به ارسال
    /// </summary>
    [Display(Name = "در حال بررسی")] ReadyToPost = 9,

    /// <summary>
    /// ارسال شده
    /// </summary>
    [Display(Name = "در حال بررسی")] Posted = 4,

    /// <summary>
    /// دارای نقص
    /// </summary>
    [Display(Name = "دارای نقص")] Defective01 = 5,
    /// <summary>
    /// دارای نقص
    /// </summary>
    [Display(Name = "دارای نقص")] Defective02 = 50,

    /// <summary>
    /// تکمیل شده
    /// </summary>
    [Display(Name = "در حال بررسی")] Completed = 6,
    [Display(Name = "در حال بررسی")] CompletedCapacity = 7,
    [Display(Name = "در حال بررسی")] Notification = 8,
    [Display(Name = "در حال بررسی")] Contact = 80,
    [Display(Name = "در حال بررسی")] AcceptToSend = 3,
    [Display(Name = "در حال بررسی")] ReadyToPay = 12,
    [Display(Name = "پرداخت شده")] Paid = 10,
    [Display(Name = "مردود شده")] Conflict = 11,
    [Display(Name = "مردود شده")] Rejected = 13
}