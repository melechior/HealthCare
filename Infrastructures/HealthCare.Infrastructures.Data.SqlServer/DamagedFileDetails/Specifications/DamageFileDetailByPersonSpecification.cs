using System;
using System.Linq.Expressions;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Framework.Specification;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Specifications;

internal class DamageFileDetailByPersonSpecification(long? personId)
    : Specification<DamageFileDetail>
{
    public override bool IsSatisfiedBy(DamageFileDetail candidate)
    {
        throw new NotImplementedException();
    }

    public override Expression<Func<DamageFileDetail, bool>> IsSatisfied()
    {
        if (!personId.HasValue)
        {
            return x => true;
        }

        return p => p.ContractOfPerson.PersonageId == personId.Value;
    }
}