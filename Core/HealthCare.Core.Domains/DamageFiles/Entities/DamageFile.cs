

using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.Users.Entities;
using HealthCare.Framework.Domain;

namespace HealthCare.Core.Domains.DamageFiles.Entities;

public class DamageFile : BaseEntity
{
    public string ReceiverUser { get; set; }
     public long? ReceiptNumber { get; set; }
    public DateTime ReceiptDate { get; set; }

    public ICollection<DamageFileDetail> DamageFileDetails { get; set; }
 

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}