using HealthCare.Core.Domains.Users.Dtos;
using HealthCare.Framework.Paging;

namespace HealthCare.Core.Domains.Users.Repositories;

public interface IUserQueryRepository
{
    PagedQueryResult<UserDto> GetFilter(string username, string fullname, bool? isActive,
        string organizationName, string roleName, string post, int pageIndex, int pageSize, string sortName = null,
        string sortType = "asc");

    PagedQueryResult<UserDto> GetFilter(string username, string firstname, string lastname, bool? isActive,
        int pageIndex, int pageSize);

    Entities.User? GetById(long id);

    Entities.User? GetUserByUsername(string username);
    // List<Entities.User> GetUsersByRole(OrganizationType organizationType, long organizationId);
    // List<Entities.User> GetUserByActor(OrganizationType organizationType, long roleId);
    // OrganizationType GetOrganizationTypeByUserId(long id);
    // long GetMaxAmountByUserId(long id);
    // long GetMaxApproveBudgetAmountByUserId(long id);
    // Organization GetOrganizationByUserId(long id);
    // Entities.User GetIssuerUserByProcessId(Guid processId, string schemeCode);
}