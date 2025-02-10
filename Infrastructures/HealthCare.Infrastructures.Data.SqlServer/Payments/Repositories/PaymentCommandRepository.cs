using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Payments.Repositories;

namespace HealthCare.Infrastructures.Data.SqlServer.Payments.Repositories;

public class PaymentCommandRepository (HealthCareDbContext context) : IPaymentCommandRepository
{
    public void Create(Payment payment)
    {
        throw new NotImplementedException();
    }

    public void Edit(Payment payment)
    {
        throw new NotImplementedException();
    }

    public void Delete(Payment payment)
    {
        throw new NotImplementedException();
    }
}