using System;
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.Personages.Dtos;

public class PersonageDto: Dto
{
    public string NationalId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public DateTime? Birthdate { get; set; }
    public string FatherName { get; set; }
    public bool? IsMan { get; set; }
    /// <summary>
    /// شماره شناسنامه
    /// </summary>
    public string BirthCertificateNumber { get; set; }

    public bool IsActive { get; set; }

    public string ActiveContracts { get; set; }
}
