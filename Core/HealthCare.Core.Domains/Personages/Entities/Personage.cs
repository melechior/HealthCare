using HealthCare.Core.Domains.ContractOfPersons.Entities;
using HealthCare.Framework.Domain;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared;
using HealthCare.Infrastructures.Shared.Helpers;


namespace HealthCare.Core.Domains.DamageFiles.Entities;
public partial class Personage : BaseEntity
{
    /// <summary>
    /// کد ملی فرد
    /// </summary>
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
    public long? InsuranceCoding { get; set; }
    
    
    public ICollection<ContractOfPerson> MainContractOfPersons { get; set; }
    public ICollection<ContractOfPerson> ContractOfPersons { get; set; }
 

    protected override void Validate()
    {
        if (!string.IsNullOrEmpty(MobileNumber) && !Regexes.MobileRegex().IsMatch(MobileNumber))
        {
            AddBrokenRule(new ResultMessage
            {
                MessageType = MessageType.Danger,
                MessageResource = MessageResource.MobileIncorrect,
                Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.MobileIncorrect)
            });
        }
        
        if (string.IsNullOrEmpty(NationalId) || !NationalId.IsValidIranianNationalCode())
        {
            AddBrokenRule(new ResultMessage
            {
                MessageType = MessageType.Danger,
                MessageResource = MessageResource.NationalIdIncorrect,
                Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.NationalIdIncorrect)
            });
        }
    }
}