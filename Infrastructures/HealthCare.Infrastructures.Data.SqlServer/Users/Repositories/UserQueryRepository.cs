using HealthCare.Core.Domains.Users.Dtos;
using HealthCare.Core.Domains.Users.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Framework.Paging;

namespace HealthCare.Infrastructures.Data.SqlServer.Users.Repositories;

public class UserQueryRepository(HealthCareDbContext context) : IUserQueryRepository
{
    public PagedQueryResult<UserDto> GetFilter(string username, string fullname, bool? isActive, string organizationName, string roleName,
        string post, int pageIndex, int pageSize, string sortName = null, string sortType = "asc")
    {
        throw new NotImplementedException();
    }

    public PagedQueryResult<UserDto> GetFilter(string username, string firstname, string lastname, bool? isActive, int pageIndex,
        int pageSize)
    {
        throw new NotImplementedException();
    }

    public User? GetById(long id)
    {
        return context.Users.FirstOrDefault(x => x.Id == id);
    }

    public User? GetUserByUsername(string username)
    {
        return context.Users
          .FirstOrDefault(x => x.Username == username || x.NationalId == username);
        //done
    }
 
}