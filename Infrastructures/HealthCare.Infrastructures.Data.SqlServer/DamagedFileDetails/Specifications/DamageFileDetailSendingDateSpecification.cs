using System.Linq.Expressions;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Framework.Specification;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Specifications;

internal class DamageFileDetailSendingDateSpecification(DateTime? fromDate, DateTime? toDate)
    : Specification<DamageFileDetail>
{
    public override bool IsSatisfiedBy(DamageFileDetail candidate)
    {
        throw new NotImplementedException();
    }

    public override Expression<Func<DamageFileDetail, bool>> IsSatisfied()
    {
        if (!fromDate.HasValue && !toDate.HasValue)
        {
            return p => true;
        }

        if (fromDate.HasValue && toDate.HasValue)
        {
            return p => p.SendToInsuranceDate >= fromDate && p.SendToInsuranceDate <= toDate;
        }

        if (fromDate.HasValue)
        {
            return p => p.SendToInsuranceDate >= fromDate;
        }

        return p => p.SendToInsuranceDate <= toDate;
    }
}