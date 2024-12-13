using Asp.Versioning;
using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpGet("GetUserInfo")]
    public IActionResult GetV1()
    {
        var query = new UserByFilterQuery();

        var users = QueryDispatcher.Dispatch<QueryResult<PagedQueryResult<UserByFilterQueryView>>>(query);

        return Ok(users);
    }
}