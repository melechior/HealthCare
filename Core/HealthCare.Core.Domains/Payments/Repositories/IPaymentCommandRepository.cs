using HealthCare.Core.Domains.DamageFiles.Entities;

namespace HealthCare.Core.Domains.Payments.Repositories;

public interface IPaymentCommandRepository
{
    void Create(Payment payment);
    void Edit(Payment payment);
    void Delete(Payment payment);
}