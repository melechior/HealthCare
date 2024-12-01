using System;
using HealthCare.Framework.Dto;

namespace HealthCare.Core.Domains.DamageFiles.Dtos;

public class DamageFileListDto: Dto
{
    public long ContractId { get; set; }
    public string ContractName { get; set; }
    public long? HumanReceiptNumber { get; set; }
    public string? SystemReceiptNumber { get; set; }
    public string ReceiptDate { get; set; }
    public string MainPersonNationalId { get; set; }
    public string MainPersonFullname { get; set; }
    public int CountOfDetails { get; set; }
}