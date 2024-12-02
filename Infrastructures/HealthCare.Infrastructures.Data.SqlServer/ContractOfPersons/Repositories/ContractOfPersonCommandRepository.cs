 
using HealthCare.Core.Domains.ContractOfPersons.Entities;
using HealthCare.Core.Domains.Users.Repositories;

namespace HealthCare.Infrastructures.Data.SqlServer.ContractOfPersons.Repositories;

public class ContractOfPersonCommandRepository(HealthCareDbContext context) : IContractofPersonCommandRepository
{
    public void Create(ContractOfPerson contractOfPerson)
    {
        context.ContractOfPeople.Add(contractOfPerson);
    }

    public void Create(List<ContractOfPerson> contractOfPersons)
    {
        context.ContractOfPeople.AddRange(contractOfPersons);
    }

    public void Edit(ContractOfPerson contractOfPerson)
    {
        context.ContractOfPeople.Update(contractOfPerson);
    }

    public void Delete(ContractOfPerson contractOfPerson)
    {
        context.ContractOfPeople.Remove(contractOfPerson);
    }
}