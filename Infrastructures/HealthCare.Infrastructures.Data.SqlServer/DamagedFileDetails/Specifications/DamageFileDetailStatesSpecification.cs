using System;
using System.Linq.Expressions;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Framework.Specification;
using HealthCare.Infrastructures.Shared.Enums;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Specifications;

internal class DamageFileDetailStatesSpecification(List<DamageFileState>? damageFileStates)
    : Specification<DamageFileDetail>
{
    public List<DamageFileState>? DamageFileStates { get; } = damageFileStates;

    public override bool IsSatisfiedBy(DamageFileDetail candidate)
    {
        throw new NotImplementedException();
    }

    public override Expression<Func<DamageFileDetail, bool>> IsSatisfied()
    {
        if (DamageFileStates == null || DamageFileStates.Count < 1)
        {
            return p => true;
        }

        Expression<Func<DamageFileDetail, bool>> o = null;
        foreach (var item in DamageFileStates)
        {
            o = o == null
                ? p => p.DamageFileState == item
                : o.Or(p => p.DamageFileState == item);
        }

        return o;
    }
}