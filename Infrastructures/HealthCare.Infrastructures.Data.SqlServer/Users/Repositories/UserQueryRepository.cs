using HealthCare.Core.Domains.Users.Dtos;
using HealthCare.Core.Domains.Users.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Framework.Paging;

namespace HealthCare.Infrastructures.Data.SqlServer.Users.Repositories;

public class UserQueryRepository(HealthCareDbContext context) : IUserQueryRepository
{
    public PagedQueryResult<UserDto> GetFilter(string username, string fullname, bool? isActive,
        string organizationName, string roleName, string post, int pageIndex, int pageSize, string sortName = null,
        string sortType = "asc")
    {
        // var userUserameSpecification = new UserUsernameSpecification(username);
        // var userIsActiveSpecification = new UserIsActiveSpecification(isActive);

        var query = context.Users
            // .Where(userUserameSpecification.IsSatisfied()
            //     .And(userIsActiveSpecification.IsSatisfied()))
            .Select(y => new UserDto
            {
                Id = y.Id,
                Email = y.Email,
                IsActive = y.IsActive,
                Username = y.Username,
                ImageAddress = y.ImageAddress,
                JobPosition = y.JobPosition,
                FirstName = y.FirstName,
                LastName = y.LastName,
                IsAdmin = y.IsAdmin
            });

        var result = new PagedQueryResult<UserDto>
        {
            PageSize = pageSize,
            CurrentPage = pageIndex,
            TotalCount = query.Count(),
            Data = query
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToList()
        };

        return result;
    }

    public PagedQueryResult<UserDto> GetFilter(string username, string firstname, string lastname, bool? isActive,
        int pageIndex,
        int pageSize)
    {
        var query = context.Users
            // .Where(userUserameSpecification.IsSatisfied()
            //     .And(userIsActiveSpecification.IsSatisfied()))
            .Select(y => new UserDto
            {
                Id = y.Id,
                Email = y.Email,
                IsActive = y.IsActive,
                Username = y.Username,
                ImageAddress = y.ImageAddress,
                JobPosition = y.JobPosition,
                FirstName = y.FirstName,
                LastName = y.LastName,
                IsAdmin = y.IsAdmin
            });
        // if (sortType == "asc")
        // {
        //     switch (sortName)
        //     {
        //         case "Username":
        //             query = query.OrderBy(x => x.Username);
        //             break;
        //         case "Firstname":
        //             query = query.OrderBy(x => x.FirstName);
        //             break;
        //         case "Lastname":
        //             query = query.OrderBy(x => x.LastName);
        //             break;
        //         // case "Role":
        //         //     query = query.OrderBy(x => x.RoleId);
        //             break;
        //     }
        // }
        // else
        // {
        //     switch (sortName)
        //     {
        //         case "Username":
        //             query = query.OrderByDescending(x => x.Username);
        //             break;
        //         case "FullName":
        //             query = query.OrderByDescending(x => x.Fullname);
        //             break;
        //         case "Organization":
        //             query = query.OrderByDescending(x => x.OrganizationName);
        //             break;
        //         case "Role":
        //             query = query.OrderByDescending(x => x.RoleId);
        //             break;
        //     }
        // }

        var result = new PagedQueryResult<UserDto>
        {
            PageSize = pageSize,
            CurrentPage = pageIndex,
            TotalCount = query.Count(),
            Data = query
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToList()
        };

        return result;
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