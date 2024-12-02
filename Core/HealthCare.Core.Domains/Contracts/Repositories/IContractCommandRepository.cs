
using HealthCare.Core.Domains.Contracts.Entities;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IContractCommandRepository
{
    void Create(Contract contract);
    void Edit(Contract contract);
    void Delete(Contract contract);
    void RefreshContractInfo(long contractId);
}