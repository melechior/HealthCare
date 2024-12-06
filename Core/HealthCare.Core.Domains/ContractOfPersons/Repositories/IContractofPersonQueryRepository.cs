
using HealthCare.Core.Domains.ContractOfPersons.Dtos;
using HealthCare.Core.Domains.ContractOfPersons.Entities;
using HealthCare.Framework.Paging;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IContractOfPersonQueryRepository
{
       ContractOfPerson? GetById(long id);
    PagedQueryResult<ContractOfPersonDto> GetByFilter(int pageIndex, int pageSize);
    IList<ContractOfPerson> GetByFilter(long? contractId = null);
    ContractOfPerson GetContractOfPerson(long contractId,long personId);
    List<ContractOfPersonByMainPersonDto> GetContractOfPersonByMainPerson(long contractId, long personId);
    List<ContractOfPersonByMainPersonDto> GetContractOfPersonByMainPersonNationalId(string nationalId);
    List<InsuranceContractPersonDto> GetInsuranceContract(long contractId);
}
