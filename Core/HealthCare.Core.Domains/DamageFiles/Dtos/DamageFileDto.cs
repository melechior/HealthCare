 
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.DamageFiles.Dtos;

public class DamageFileDto: Dto
{
    public long? ReceiptNumber { get; set; }
    public DateTime CreationDate { get; set; }
    public string PersianCreationDate { get; set; }
    public string ContractName { get; set; }
    public string ContractNumber { get; set; }
    public string Fullname { get; set; }
}