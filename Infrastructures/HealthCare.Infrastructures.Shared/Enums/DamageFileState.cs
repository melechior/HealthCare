using System.ComponentModel.DataAnnotations;

namespace HealthCare.Infrastructures.Shared.Enums;

public enum DamageFileState
{
    /// <summary>
    /// ثبت اولیه
    /// </summary>
    [Display(Name = "ثبت اولیه")] InitialRegistration = 1,

    /// <summary>
    /// ثبت اسناد
    /// </summary>
    [Display(Name = "ثبت اسناد")] RegistrationDocuments = 2,

    /// <summary>
    /// آماده به ارسال
    /// </summary>
    [Display(Name = "آماده به ارسال")] ReadyToPost = 9,

    /// <summary>
    /// ارسال شده
    /// </summary>
    [Display(Name = "ارسال شده")] Posted = 4,

    /// <summary>
    /// دارای نقص
    /// </summary>
    [Display(Name = "دارای نقص")] Defective = 5,

    /// <summary>
    /// تکمیل شده
    /// </summary>
    [Display(Name = "تکمیل شده")] Completed = 6,
    [Display(Name = "تکمیل ظرفیت شده")] CompletedCapacity = 7,
    [Display(Name = "تذکر")] Notification = 8,
    [Display(Name = "تایید نهایی")] AcceptToSend = 3,
    [Display(Name = "آماده به پرداخت")] ReadyToPay = 12,
    [Display(Name = "پرداخت شده")] Paid = 10,
    [Display(Name = "دارای مغایرت پرداختی")] Conflict = 11,
    [Display(Name = "مردود شده")] Rejected = 13
}