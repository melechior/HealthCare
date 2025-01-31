using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Enums;
 

namespace HealthCare.Core.Domains.DamagedFileDetails.Queries
{
    public class DamageFileDetailByPendingStateQuery : IQuery
    {
        public long? PersonId { get; set; }
        public List<DamageFileState>? DamageFileStates { get; set; } = [];
        public string SearchValue { get; set; } = null;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
