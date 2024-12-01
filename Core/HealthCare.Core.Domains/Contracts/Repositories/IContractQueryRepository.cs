

using HealthCare.Core.Domains.Contracts.Dto;
using HealthCare.Core.Domains.Contracts.Dtos;
using HealthCare.Core.Domains.Contracts.Entities;
using HealthCare.Framework.Paging;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IContractQueryRepository
{
     Contract? GetById(long id);

    PagedQueryResult<ContractDto> GetByFilter(int pageIndex, int pageSize);
    IList<Contract> GetByFilter();
    List<ContractDto> GetActiveContractByPersonId(long personId);
}