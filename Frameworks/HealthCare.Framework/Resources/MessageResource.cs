using System.ComponentModel.DataAnnotations;

namespace HealthCare.Framework.Resources
{
    public enum MessageResource : int
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Successed = 0,

        [Display(Name = "عملیات با خطا روبه رو شد")]
        Failed = 1,

        [Display(Name = "نام کاربری خالی می باشد")]
        UsernameIsEmpty = 3,

        [Display(Name = "رمز عبور خالی می باشد")]
        PasswordIsEmpty = 4,

        [Display(Name = "کاربر یافت نشد")] 
        UserNotFound = 5,

        [Display(Name = "خطایی در سیستم رخ داده است، لطفا با پشتيباني تماس حاصل فرماييد")]
        ErrorHasBeenOccoured = 715,

        [Display(Name = "شماره تماس درست نمی باشد")]
        MobileIncorrect = 6,
        
        [Display(Name = "کد ملی درست نمی باشد")]
        NationalIdIncorrect = 7,
        
        [Display(Name = "پست الکترونیکی اشتباه می باشد")]
        EmailFormatIncorrect = 8,
        
        [Display(Name = "کاربر غیر فعال می باشد")]
        UserIsInActive = 9,
        
        [Display(Name = "کاربر تکراری است")]
        UserIsDuplicate = 10,
        [Display(Name = "اطلاعات تکراری است")]
        DataIsDuplicate = 11,
        [Display(Name = "اطلاعات مورد نظر یافت نشد")] 
        DataNotFound = 12,
        [Display(Name = "فرمت اطلاعات مورد نظر اشتباه می باشد")] 
        DataFormatIncorrect = 13,
        
        [Display(Name = "قرارداد یافت نشد")] 
        ContractNotFound = 14,
        
        [Display(Name = "بیمه شده یافت نشد")] 
        PersonageNotFound = 15,
        
        [Display(Name = "شما مجاز به این عملیات نمی باشید")] 
        DontHaveAccess = 16,
        
        [Display(Name = "سقف موجود خسارت")] 
        Overflow = 17,
        
        [Display(Name = "خطا یا خطاهایی در فایل وجود دارد لطفا گزارش را مطالعه فرمایید")] 
        FileHaveError = 20,
        
        [Display(Name = "فرمت فایل صحیح نمی باشد لطفا فایل مورد نظر را بررسی فرمایید")] 
        FileFormatHaveError = 21,
        
        [Display(Name = "کلمه عبور مغایرت دارد")] 
        PasswordNotConfirm = 22,
        
        [Display(Name = "بانک یافت نشد")] 
        BankNotFound = 23,
        
        
        
    }
}