using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpGet("GetUserInfo")]
    public IActionResult GetV1()
    {
        return Ok("This is version 1.0");
    }
}

