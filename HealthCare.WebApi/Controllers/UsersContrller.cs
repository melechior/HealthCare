using HealthCare.Core.Domains.Users.Commands;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
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
    [HttpPost("ResetUserPassword")]
    public IActionResult ResetUsersPass([FromBody] ResetPasswordCommand command)
    {
        var result = CommandDispatcher.Dispatch(command);

        return Ok(result);
    }
}