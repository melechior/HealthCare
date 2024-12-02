 

namespace HealthCare.Core.Domains.DamageFiles.Dtos;

public class DamageMoalemReportDto
{
public string PersonName { get; set; }
    public string PersonNNationalId { get; set; }
    public string Relative { get; set; }
    public string DamageDate { get; set; }
    public string DamageItem { get; set; }
    public decimal DamageAmount { get; set; }
    public string MainPersonName { get; set; }
    public string ContractName { get; set; }
    public string MainNationalId { get; set; }
    public string SystemReceiptNumber { get; set; }
    public string ReceiptNumber { get; set; }
    public string SendDate { get; set; }
    public string ReceiveDate { get; set; }
}
