using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.DamagedFileDetails.QueryViews;

public class DamageFileDetailByStateQueryView : QueryView
{
    public decimal RequestedAmount { get; set; }
    public string Description { get; set; }
    public DamageFileState DamageFileState { get; set; }
    public string DamageFileStateName { get; set; }
    public DateTime DamageDate { get; set; }
    public string PersianDamageDate { get; set; }
    public long DamageFileId { get; set; }
    public string ReceiptNumber { get; set; }
    public DateTime DamageFileCreationDate { get; set; }
    public string DamageFilePersianCreationDate { get; set; }
    public string ContractName { get; set; }
    public string Fullname { get; set; }
    //public decimal DamageItemId { get; set; }
    public string DamageItemName { get; set; }
    public string ContractNumber { get; set; }
}