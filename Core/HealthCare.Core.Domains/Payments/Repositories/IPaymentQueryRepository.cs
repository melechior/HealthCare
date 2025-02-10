
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Framework.Paging;

namespace HealthCare.Core.Domain.Payments.Repositories;

public interface IPaymentQueryRepository
{
    // PagedQueryResult<PaymentDto> GetFilter();
    //
    // PagedQueryResult<PaymentDto> GetFilter(int pageIndex, int pageSize);

    Payment? GetById(long id);
    List<Payment> GetByIds(List<long> ids);
    List<DamageFileDetail> GetByPaymentId(long id);
    List<Payment> GetByDamageFileDetailId(long id);
}