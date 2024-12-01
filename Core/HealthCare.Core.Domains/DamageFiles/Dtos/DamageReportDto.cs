using System;
using HealthCare.Framework.Dto;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.DamageFiles.Dtos;

public class DamageReportDto: Dto
{
    public long PersonId { get; set; }
    public long MainPersonId { get; set; }
    public long ContractId { get; set; }
    public string AssuranceName { get; set; }
    public string MainPerson { get; set; }
    public string ReceiptNumber { get; set; }
    public string MainPersonTel { get; set; }
    public DateTime? ReceiptDate { get; set; }

    public long DamageFileDetailId { get; set; }
    public string PersonName { get; set; }
    public string PersonNationalId { get; set; }
    public long DamageItemId { get; set; }
    public string DamageItemName { get; set; }
    public DateTime DamageDate { get; set; }
    public decimal DamageAmount { get; set; }
    public string Description { get; set; }
    public DamageFileState State { get; set; }
}