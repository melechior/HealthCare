using System;
using System.Linq.Expressions;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Framework.Specification;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Specifications;

internal class DamageFileDetailReceiptNumberSpecification(string? receiptNumber)
    : Specification<DamageFileDetail>
{
    public override bool IsSatisfiedBy(DamageFileDetail candidate)
    {
        throw new NotImplementedException();
    }

    public override Expression<Func<DamageFileDetail, bool>> IsSatisfied()
    {
        if (string.IsNullOrWhiteSpace(receiptNumber))
        {
            return x => true;
        }

        return p => p.DamageFile.ReceiptNumber.ToString()!.StartsWith(receiptNumber) ||
                    p.DamageFile.Id.ToString()!.StartsWith(receiptNumber);
    }
}