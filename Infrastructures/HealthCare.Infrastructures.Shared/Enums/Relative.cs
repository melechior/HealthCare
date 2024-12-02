using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace HealthCare.Infrastructures.Shared.Enums;

public enum Relative
{
    /// <summary>
    /// بیمه شده اصلی
    /// </summary>
    [Display(Name = "اصلی")] Main = 1,

    /// <summary>
    /// همسر
    /// </summary>
    [Display(Name = "همسر")] Partner = 2,

    /// <summary>
    /// فرزند
    /// </summary>
    [Display(Name = "فرزند")] Offspring = 3,
    
    /// <summary>
    /// پدر
    /// </summary>
    [Display(Name = "پدر")] Father = 4,

    /// <summary>
    /// مادر
    /// </summary>
    [Display(Name = "مادر")] Mother = 5,
    
    /// <summary>
    /// فرزند دختر
    /// </summary>
    [Display(Name = "دختر")] Daughter = 6,

    /// <summary>
    /// فرزند پسر
    /// </summary>
    [Display(Name = "پسر")] Son = 7,

    /// <summary>
    /// تحت تکفل
    /// </summary>
    [Display(Name = "تحت تکفل")] Dependent = 8,
    
    /// <summary>
    /// خواهر
    /// </summary>
    [Display(Name = "خواهر")] Sister = 9,
    
    /// <summary>
    /// برادر
    /// </summary>
    [Display(Name = "برادر")] Brother = 10,
}