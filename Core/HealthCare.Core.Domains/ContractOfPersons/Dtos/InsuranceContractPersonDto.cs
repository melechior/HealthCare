using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.ContractOfPersons.Dtos;

public class InsuranceContractPersonDto: Dto
{
    public string Name { get; set; }
    public string LName { get; set; }
    public string PersonelCode { get; set; }
    public string IdentityNo { get; set; } 
    public int BirthYear { get; set; }
    public int BirthMonth { get; set; }
    public int BirthDay { get; set; }
    public string CodeMelli { get; set; }
    public string Mobile { get; set; }
    public int Jens { get; set; }
    public string FatherName { get; set; }
    public int BSKind { get; set; }
    public int Nesbat { get; set; }
    public string BeginDate { get; set; }
    public string EndDate { get; set; }
    public int TakafolKind { get; set; }
    public int Tarh { get; set; }
    public string AccNO { get; set; }
    public string Sheba { get; set; }
    public string BankName { get; set; }
    public string MainNationalId { get; set; }
}