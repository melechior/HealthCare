using System;
using System.Linq.Expressions;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Framework.Specification;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Specifications;

internal class DamageFileDetailsSearchValueSpecification(string? searchValue) : Specification<DamageFileDetail>
{
    public override bool IsSatisfiedBy(DamageFileDetail candidate)
    {
        throw new NotImplementedException();
    }

    public override Expression<Func<DamageFileDetail, bool>> IsSatisfied()
    {
        if (string.IsNullOrEmpty(searchValue))
        {
            return p => true;
        }

        return p => p.DamageFile.ReceiptNumber.Value.ToString().StartsWith(searchValue) ||
                    p.DamageFile.Id.ToString().StartsWith(searchValue);
    }
}