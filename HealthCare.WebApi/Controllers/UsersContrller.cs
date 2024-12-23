using Asp.Versioning;
using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Core.Domains.Users.Commands;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.Infrastructures.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpGet("GetUserInfo")]
    public IActionResult GetV1([FromQuery] UserByFilterQuery query)
    {
        var users = QueryDispatcher.Dispatch<QueryResult<PagedQueryResult<UserByFilterQueryView>>>(query);

        return Ok(users);
    }
    [HttpGet("ResetUsermPass")]
    public IActionResult ResetUsersPass([FromQuery] ResetPassWorldCommand query)
    {
        var users = QueryDispatcher.Dispatch<QueryResult<PagedQueryResult<ResetPassWorldCommand>>>(query);

        return Ok(users);
    }
}