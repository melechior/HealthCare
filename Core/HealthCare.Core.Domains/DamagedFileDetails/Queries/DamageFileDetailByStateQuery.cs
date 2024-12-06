using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Core.Domains.DamagedFileDetails.Queries;

public class DamageFileDetailByStateQuery : PagedQuery, IQuery
{
    public long? PersonId { get; set; }
    public List<DamageFileState>? DamageFileStates { get; set; } = [];
    public string SearchValue { get; set; }
}