using HealthCare.Core.Domains.ContractOfPersons.Entities;
 

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IContractofPersonCommandRepository
{
    void Create(ContractOfPerson contractOfPerson);
    void Create(List<ContractOfPerson> contractOfPersons);
    void Edit(ContractOfPerson contractOfPerson);
    void Delete(ContractOfPerson contractOfPerson);
}