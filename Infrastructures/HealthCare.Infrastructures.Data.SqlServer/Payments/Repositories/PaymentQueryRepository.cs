
using HealthCare.Core.Domain.Payments.Repositories;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Framework.Paging;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructures.Data.SqlServer.Payments.Repositories;

public class PaymentQueryRepository(HealthCareDbContext context) : IPaymentQueryRepository
{
    public Payment? GetById(long id)
    {
        return context.Payment.FirstOrDefault(x => x.Id == id);
    }

    public List<Payment> GetByIds(List<long> ids)
    {
        return context.Payment.Where(x => ids.Contains(x.Id)).ToList();
    }

    public List<DamageFileDetail> GetByPaymentId(long id)
    {
        return context.DamageFileDetails
            .Include(x=>x.DamageItem)
            .Where(x => x.PaymentDamageFiles.Any(y => y.PaymentId == id)).ToList();
    }

    public List<Payment> GetByDamageFileDetailId(long id)
    {
        return context.Payment
            .Where(x => x.PaymentDamageFiles.Any(y => y.DamageFileDetailId == id)).ToList();
    }
}